using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace NimGameProject.GameLogic
{
    internal class GameState
    {
        private const int MAX_ROW = 10; //số đống tối đa là 10
        private const int MAX_COL = 10; //số vật phẩm tối đa là 10
        private const int MIN_ROW = 1;
        private const int MIN_COL = 1;

        private int pilesCount; //số đống N, 
        private int[] piles; //số lượng mỗi đống
        private bool currentPlayer; //0 player1; 1 player2
        private bool isGameOver; //kiểm tra trạng thái trò chơi kết thúc chưa

        private Random random;

        public GameState() //tạo game mặc định
        {
            this.pilesCount = 4;
            this.currentPlayer = false;
            this.isGameOver = false;

            piles = new int[4];

            for (int i = 0; i < 4; i++)
            {
                piles[i] = i + 1;
            }
            //tạo trò chơi kiểu mặc định
            //O
            //OO
            //OOO
            //OOOO
        }

        public GameState(int pilesCount, int[] piles, bool currentPlayer, bool isGameOver)
        {
            this.pilesCount = pilesCount;
            this.piles = piles;
            this.currentPlayer = currentPlayer;
            this.isGameOver = isGameOver;
            this.random = new Random();
        }

        public GameState(int pilesCount, int min, int max) //tạo game với số đống cụ thể và số lượng vật phẩm ngẫu nhiên
        {
            CreateRandom(pilesCount, min, max);
        }

        public GameState(GameState gameState)
        {
            this.pilesCount = gameState.pilesCount;
            this.currentPlayer = gameState.currentPlayer;
            this.isGameOver = gameState.isGameOver;

            this.piles = gameState.piles.ToArray();
        }

        public GameState(bool currentPlayer, int[,] board)
        {
            this.currentPlayer = currentPlayer;
            this.isGameOver = false;

            this.pilesCount = board.GetLength(0);

            for(int i = 0; i < board.GetLength(0); i++) //khởi tạo = 0
            {
                this.piles[i] = 0;
            }

            for(int i = 0; i <  board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0) this.piles[i]++;
                }
            }
        }

        public void CreateRandom(int pilesCount, int min, int max)
        {
            this.pilesCount = pilesCount;
            this.currentPlayer = false;
            this.isGameOver = false;

            piles = new int[pilesCount];

            random = new Random();

            for (int i = 0; i < pilesCount; i++)
            {

                piles[i] = random.Next(min, max + 1);
            }
        }

        public int GetMaxInPiles()
        {
            int max = 0;
            for (int i = 0; i < this.pilesCount; i++)
            {
                if (this.piles[i] > max) max = this.piles[i];
            }
            return max;
        }
        public int[,] GetStateBoard()
        {
            int max = this.GetMaxInPiles();


            int[,] board = new int[this.pilesCount, max];
            for (int i = 0; i < pilesCount; i++)
            {
                for (int j = 0; j < piles[i]; j++)
                {
                    board[i, j] = 0;
                }
                for (int j = piles[i]; j < max; j++)
                {
                    board[i, j] = -1;
                }
            }

            return board;
        }

        public GameState CloneGameState()
        {
            GameState stateClone = new GameState(this);
            return stateClone;
        }

        public int PilesCount { get { return pilesCount; } set { pilesCount = value; } }
        public int[] Piles { get { return piles; } private set { } }
        public bool CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        public bool IsGameOver { get { return isGameOver; } set { isGameOver = value; } }

    }
    
}
