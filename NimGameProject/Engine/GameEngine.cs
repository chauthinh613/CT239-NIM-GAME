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

        public int[][] Board { get { return gameState.Board; } }
        //-1: không có item
        //0: item chưa được chọn
        //1: item đã được chọn

        private bool isPVP; //0 chơi với máy, 1 người với người
        public bool IsPVP { get { return isPVP; } }

        private GameState gameState;
        private Stack<Step> historySteps; //lưu stack các nước đi

        private bool isInTurn; //kiểm tra lượt chơi người đó còn hay không

        private int selectedPileIndex; // chỉ số đống
        private int selectedCount; //số lượng chọn trong đống

        private Random random;

        //get set

        //public int[][] Board { get { return board; } }
        public bool IsInTurn { get { return isInTurn; } set { isInTurn = value; } }
        public GameState GameState { get { return gameState; } }
        public int SelectedPileIndex { get { return selectedPileIndex; } set { selectedPileIndex = value; } }


        public GameEngine()
        {
            gameState = new GameState();

            historySteps = new Stack<Step>();

            isInTurn = false;
            selectedPileIndex = 0;
            selectedCount = 0;

            isPVP = true;
        }

        public GameEngine(bool isPVP, GameState gameState)
        {
            this.gameState = gameState;

            historySteps = new Stack<Step>();

            isInTurn = false;
            selectedPileIndex = 0;
            selectedCount = 0;

            this.isPVP = isPVP;
        }

        public GameEngine(bool isPVP, GameConfig config)
        {
            gameState = new GameState(config.Rows, 1, config.MaxColumns);

            historySteps = new Stack<Step>();

            selectedPileIndex = 0;
            selectedCount = 0;

            this.isPVP = isPVP;
        }
        

        
        public bool ChosenItem(int i, int j, bool currentPlayer)
        {
            if (!isInTurn)
            {
                isInTurn = true; //cho vào lượt
                selectedPileIndex = i;
            }
            if (!CheckSamePile(i))
            {
                return false;
            }
            else
            {
                //chosenItems += 1; //đống của hàng đó chuẩn bị trừ đi 1
                RemoveItems(selectedPileIndex, 1);

                //chosenItems++;

                gameState.Board[i][j] = 1;

                historySteps.Push(CreateStep(i, j, currentPlayer));

                ChosenPileEvent.Invoke();

                if(gameState.Piles[selectedPileIndex] == 0) //nếu lấy hết thì tự đổi lượt
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

        public bool UndoInTurn()
        {
            if (historySteps.Count == 0 || !isInTurn) return false; //rỗng thì hông undo được

            Step lastStep = historySteps.Pop();

            if (lastStep.CurrentPlayer != gameState.CurrentPlayer) return false; //nếu lượt hông phải thì hông undo được
            
            // hoàn lại item trên board
            gameState.Board[lastStep.Row][lastStep.Col] = 0;

            // hoàn lại số lượng pile
            gameState.Piles[lastStep.Row] += 1;

            // nếu stack rỗng sau khi undo thì reset lượt, để 
            if (historySteps.Count == 0)
            {
                isInTurn = false;
                selectedPileIndex = 0;
            }

            return true;
        }

        public bool CanUndo() // kiểm tra có thể undo hông
        {
            return historySteps.Count > 0 && isInTurn;
        }

        //hàm ValidationCheck: kiểm tra giá trị nhập có hợp lệ hay không -> viết ở dưới

        public bool CheckSamePile(int pile)
        {
            if (pile == this.selectedPileIndex) return true;
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
            if (isInTurn) //nếu đang trong lượt thì có thể kết thúc
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

                    historySteps.Clear();
                }
                else GameOver();
            }

        }
        public void ClearAfterTurn() //đặt lại các thông số lựa chọn
        {
            selectedCount = 0;
            selectedPileIndex = 0;
            isInTurn = false;
        }


        //xử lý máy chơi
        public void ApplyMove(int pile, int items)
        {
            selectedPileIndex = pile;

            isInTurn = true;

            for(int i = 0; i < items; i++) //kiểm tra để chỉ lấy những ô còn item
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

            while (j < gameState.Board[selectedPileIndex].Length && gameState.Board[selectedPileIndex][j] != 0)
            {
                j++;
            }

            if (j >= gameState.Board[selectedPileIndex].Length)
                return;

            gameState.Board[selectedPileIndex][j] = 1;
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
                MakeRandomMove(); //nếu hông thì đi random
            }

            return (selectedPileIndex, selectedCount);
        }
        public int GetNimSum()
        {
            int nimSum = 0;
            for(int i = 0; i < gameState.PileCount; i++)
            {
                nimSum = nimSum ^ gameState.Piles[i];
                // nimsum = nimsum XOR pi
            }
            return nimSum;
        }
        public void MakeOptimalMove()
        {
            int nimSum = GetNimSum();
            int target = 0; //ri
            int removeItems = 0;

            for (int i = 0; i < gameState.PileCount; i++)
            {
                target = gameState.Piles[i] ^ nimSum;


                if(target < gameState.Piles[i])
                {
                    removeItems = gameState.Piles[i] - target;

                    selectedPileIndex = i;

                    break;
                }
            }

            selectedCount = removeItems;
        }
        public void MakeRandomMove()
        {
            random = new Random();
            do
            {
                selectedPileIndex = random.Next(1, gameState.PileCount + 1) - 1;
                selectedCount = random.Next(1, gameState.Piles[selectedPileIndex] + 1);
            } while (!ValidationCheck());
        }
        public bool ValidationCheck()
        {
            if (selectedPileIndex < 0 || selectedPileIndex > gameState.PileCount)
            {
                MessageBox.Show("Lỗi");
                return false;
            }
            if (gameState.Piles[selectedPileIndex] < 0)
            {
                MessageBox.Show("Lỗi");
                return false;
            }
            if (selectedCount <= 0 || selectedCount > gameState.Piles[selectedPileIndex]) { return false; }

            return true;
        }


        public bool CheckGameOver()
        {
            //lỡ nếu xong mà chưa load kịp
            if(gameState.IsGameOver) return true;

            //duyệt từng đống
            for (int i = 0; i < gameState.PileCount; i++)
            {
                if (gameState.Piles[i] > 0 && gameState.Piles != null) return false;
            }
            return true;
        }

        public void GameOver()
        {
            GameOverEvent.Invoke();
        }

        ///---test---///
        public void MessageBoard()
        {
            string t = "";
            for (int i = 0; i < gameState.Board.Length; i++) 
            {
                for(int j = 0; j < gameState.Board[i].Length; j++)
                {
                    t += string.Format("{0}, ", gameState.Board[i][j]);
                }
                t += "\n\r";
            }

            MessageBox.Show(t);
        }
    }

}
