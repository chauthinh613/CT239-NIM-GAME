using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimGameProject.GameLogic
{
    internal class GameEngine
    {
        public event Action SwitchPlayerEvent; //thông báo đổi lượt chơi
        public event Action GameOverEvent;
        public event Action ChosenPileEvent;
        public event Action ComputerMoveEvent;
        public event Action ResetRowEffectEvent;

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

        public bool IsPVP { get { return isPVP; } }

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

                ChosenPileEvent?.Invoke();

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
        public void RemoveItems(int pile, int items) //cập nhật số lượng đống
        {
            gameState.Piles[pile] -= items;
        }

        public void SwitchPlayer()
        {
            gameState.CurrentPlayer = !gameState.CurrentPlayer;

            SwitchPlayerEvent.Invoke(); //để cho bên GameForm đổi

            ClearAfterTurn();
        }
        public void EndTurn() //xử lý khi xong 1 lượt
        {
            //RemoveItems();
            if (inTurnCheck) //nếu đang trong lượt thì có thể kết thúc
            {
                gameState.IsGameOver = CheckGameOver();

                if (!gameState.IsGameOver)
                {
                    ResetRowEffectEvent.Invoke();

                    SwitchPlayer();

                    if (!isPVP && gameState.CurrentPlayer) //nếu chế độ đánh máy và tới lượt máy
                    {
                        ComputerMoveEvent.Invoke(); //gọi hàm máy chơi bên GameForm
                        //EndTurn();
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

        public void ApplyMove(int pile, int items)
        {
            chosenPile = pile;

            inTurnCheck = true;

            for(int i = 0; i < items; i++)
            {
                RemoveItems(pile, 1);
                UpdateBoard();
            }

            gameState.IsGameOver = CheckGameOver();

            EndTurn();
        }

        public void UpdateBoard()
        {
            int j = 0;

            while (j < board.GetLength(1) && board[chosenPile, j] != 0)
            {
                j++;
            }

            if (j >= board.GetLength(1))
                return;

            board[chosenPile, j] = 1;
        }


        public (int piles, int items) GetComputerMove()
        {
            int nimSum = GetNimSum(); //tính nimsum

            //chọn hàng và số lượng
            if (nimSum != 0)
            {
                MakeOptimalMove(); //nếu nim-sum != 0 thực hiện đi chiến lược tối ưu
            }
            else
            {
                MakeRandomMove(); //nếu không thì đi ngẫu nhiên
            }

            return (chosenPile, chosenItems);
        }
        public int GetNimSum()
        {
            int nimSum = 0;
            for(int i = 0; i < gameState.PilesCount; i++)
            {
                nimSum = nimSum ^ gameState.Piles[i];
                // nimsum = nimsum XOR pi
            }
            return nimSum;
        }
        public void MakeOptimalMove()
        {
            int nimSum = GetNimSum();
            int xorWithNimSum = 0; //ri
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

            chosenItems = removeItems;
        }
        public void MakeRandomMove()
        {
            do
            {
                random = new Random();
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
            //string win = "";

            GameOverEvent.Invoke();

            //if (!gameState.CurrentPlayer)
            //    win = string.Format("Nguoi choi Cho thang");
            //else
            //    win = string.Format("Nguoi choi Meo thang");

            //MessageBox.Show(win);
        }

        

        public int[,] Board
        {
            get { return board; }
        }

        public GameState GameState { get { return gameState; } }
        public int ChosenPile {  get { return chosenPile; } set { chosenPile = value; } }

        ///test///
        public void MessageBoard()
        {
            string t = "";
            for (int i = 0; i < board.GetLength(0); i++) 
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    t += string.Format("{0}, ", board[i, j]);
                }
                t += "\n\r";
            }

            MessageBox.Show(t);
        }
    }

}
