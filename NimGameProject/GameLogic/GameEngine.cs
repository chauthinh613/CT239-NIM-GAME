using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimGameProject.GameLogic
{
    internal class GameEngine
    {
        public event Action SwitchPlayerEvent; //thông báo đổi lượt chơi
        public event Action GameOverEvent;

        private const int MAX_ROW = 10; //số đống tối đa là 10
        private const int MAX_COL = 10; //số vật phẩm tối đa là 10
        private const int MIN_ROW = 1;
        private const int MIN_COL = 1;

        private int[,] board; //tạo bàn theo ô 
        //-1: không có item
        //0: item chưa được chọn
        //1: item đã được chọn

        private bool isPVP; //0 chơi với máy, 1 người với người
        private bool isEasyMode; //chế độ máy khó hay dễ

        private GameState gameState;
        private Stack<Step> historySteps; //lưu stack các nước đi

        private bool inTurnCheck; //kiểm tra lượt chơi người đó còn hay không
        private int chosenPile; // chỉ số đống
        private int chosenItems;

        private Random random;

        public GameEngine()
        {
            gameState = new GameState();

            historySteps = new Stack<Step>();

            inTurnCheck = false;
            chosenPile = 0;
            chosenItems = 0;

            isPVP = true;

            board = gameState.GetStateBoard();
        }



        public GameEngine(bool isPVP, bool isEasyMode)
        {
            gameState = new GameState();

            historySteps = new Stack<Step>();

            inTurnCheck = false;
            chosenPile = 0;
            chosenItems = 0;

            this.isPVP = isPVP;
            this.isEasyMode = isEasyMode;
        }

        public GameEngine(bool isPVP, bool isEasyMode, GameState gameState)
        {
            this.gameState = gameState;

            historySteps = new Stack<Step>();

            inTurnCheck = false;
            chosenPile = 0;
            chosenItems = 0;

            this.isPVP = isPVP;
            this.isEasyMode = isEasyMode;

            board = gameState.GetStateBoard();

            
        }
        

        
        public bool ChosenItem(int i, int j, bool currentPlayer)
        {
            if (!inTurnCheck)
            {
                inTurnCheck = true; //cho vào lượt
                chosenPile = i;
            }
            if (!CheckSamePile(i))
            {
                return false;
            }
            else
            {
                //chosenItems += 1; //đống của hàng đó chuẩn bị trừ đi 1
                RemoveItems(chosenPile, 1);

                //chosenItems++;

                board[i, j] = 1;

                historySteps.Push(CreateStep(i, j, currentPlayer));

                if(gameState.Piles[chosenPile] == 0) //nếu lấy hết thì tự đổi lượt
                {
                    EndTurn();
                }
            }
            return true;
        }

        public Step CreateStep(int i, int j, bool currentPlayer)
        {
            Step step = new Step(i, j, currentPlayer);
            return step;
        }

        //hàm ValidationCheck: kiểm tra giá trị nhập có hợp lệ hay không
        
        public bool CheckSamePile(int pile)
        {
            if (pile == this.chosenPile) return true;
            return false;
        }
        public void RemoveItems(int pile, int items)
        {
            gameState.Piles[pile] -= items;
        }

        public void SwitchPlayer()
        {
            gameState.CurrentPlayer = !gameState.CurrentPlayer;

            SwitchPlayerEvent?.Invoke(); //để cho bên GameForm đổi

            ClearAfterTurn();
        }
        public void EndTurn() //xử lý khi xong 1 lượt
        {
            //RemoveItems();
            if(inTurnCheck)
            {
                gameState.IsGameOver = CheckGameOver();

                if (!gameState.IsGameOver)
                {
                    SwitchPlayer();

                    //xử lý nếu là máy chơi
                    if (!isPVP)
                    {
                        ComputerPlayer();
                    }

                }
                else GameOver();
            }

        }
        public void ClearAfterTurn() //đặt lại các thông số lựa chọn
        {
            chosenItems = 0;
            chosenPile = 0;
            inTurnCheck = false;
        }


        //xử lý máy chơi
        public int GetNimSum()
        {
            int nimSum = 0;
            for(int i = 0; i < gameState.PilesCount; i++)
            {
                nimSum = nimSum ^ gameState.Piles[i];
            }
            return nimSum;
        }
        public void ComputerPlayer()
        {
            int nimSum = GetNimSum();
            if(nimSum != 0)
            {
                MakeOptimalMove();
            }
            else
            {
                MakeRandomMove();
            }
            ComputerGetItems();
        }

        public void ComputerGetItems()
        {
            int j = 0; //vị trí j trên board

            for(int i = 0; i < chosenItems; i++)
            {
                while (board[chosenPile, j] == 0)
                {
                    j++;
                }

                ChosenItem(i, j, gameState.CurrentPlayer);
            }
        }
        public void MakeOptimalMove()
        {
            int nimSum = GetNimSum();
            int xorWithNimSum = 0;
            int removeItems = 0;

            for (int i = 0; i < gameState.PilesCount; i++)
            {
                xorWithNimSum = gameState.Piles[i] ^ nimSum;

                if(xorWithNimSum < gameState.Piles[i])
                {
                    removeItems = gameState.Piles[i] - xorWithNimSum;

                    chosenPile = i;

                    break;
                }
            }

            for(int i = 0; i < removeItems; i++)
            {
                ChosenItem(chosenPile, i, gameState.CurrentPlayer);
            }
        }
        public void MakeRandomMove()
        {
            do
            {
                chosenPile = random.Next(1, gameState.PilesCount + 1) - 1;
                chosenItems = random.Next(1, gameState.Piles[chosenPile] + 1);
            } while (!ValidationCheck());
        }
        public bool ValidationCheck()
        {
            if (chosenPile < 0 || chosenPile > gameState.PilesCount)
            {
                MessageBox.Show("1");
                return false;
            }
            if (gameState.Piles[chosenPile] < 0)
            {
                MessageBox.Show("2");
                return false;
            }
            if (chosenItems <= 0 || chosenItems > gameState.Piles[chosenPile]) { return false; }

            return true;
        }


        public bool CheckGameOver()
        {
            //duyệt từng đống
            for (int i = 0; i < gameState.PilesCount; i++)
            {
                if (gameState.Piles[i] > 0) return false;
            }
            return true;
        }

        public void GameOver()
        {
            string win = "";

            GameOverEvent?.Invoke();

            if (!gameState.CurrentPlayer)
                win = string.Format("Nguoi choi Cho thang");
            else
                win = string.Format("Nguoi choi Meo thang");

            MessageBox.Show(win);
        }

        public int[,] Board
        {
            get { return board; }
        }

        public GameState GameState { get { return gameState; } }
        public int ChosenPile {  get { return chosenPile; } }
    }
}
