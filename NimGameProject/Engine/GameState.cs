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
        private int pileCount; //số đống N, 
        private int[] piles; //số lượng mỗi đống
        private bool currentPlayer; //0 player1; 1 player2
        private bool isGameOver; //kiểm tra trạng thái trò chơi kết thúc chưa

        private int[][] board;
        public int[][] Board { get { return board; } }
        //-1: không có item
        //0: item chưa được chọn
        //1: item đã được chọn

        // get set
        public int PileCount { get { return pileCount; } set { pileCount = value; } }
        public int[] Piles { get { return piles; } private set { } }
        public bool CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        public bool IsGameOver { get { return isGameOver; } set { isGameOver = value; } }

        private Random random;

        public GameState() //tạo game mặc định
        {
            this.pileCount = 4;
            this.currentPlayer = false;
            this.isGameOver = false;

            piles = new int[4];

            for (int i = 0; i < 4; i++)
            {
                piles[i] = i + 1;
            }

            InitBoard();
            //tạo trò chơi kiểu mặc định
        }

        public GameState(int pilesCount, int[] piles, bool currentPlayer, bool isGameOver)
        {
            this.pileCount = pilesCount;
            this.piles = piles;
            this.currentPlayer = currentPlayer;
            this.isGameOver = isGameOver;
            this.random = new Random();

            InitBoard();
        }

        public GameState(int pilesCount, int min, int max) //tạo game với số đống cụ thể và số lượng vật phẩm ngẫu nhiên
        {
            CreateRandom(pilesCount, min, max);
        }

        public GameState(GameState gameState)
        {
            this.pileCount = gameState.pileCount;
            this.currentPlayer = gameState.currentPlayer;
            this.isGameOver = gameState.isGameOver;

            this.piles = gameState.piles.ToArray();

            this.board = gameState.board
                .Select(row => row.ToArray())
                .ToArray(); //copy lại
        }

        public GameState(bool currentPlayer, int[][] board)
        {
            this.currentPlayer = currentPlayer;
            this.isGameOver = false;

            this.pileCount = board.Length;
            this.piles = new int[pileCount];

            this.board = board.Select(row => row.ToArray()).ToArray();

            for (int i = 0; i < board.Length; i++) //khởi tạo = 0
            {
                this.piles[i] = 0;
            }

            for(int i = 0; i <  board.Length; i++)
            {
                for(int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 0) this.piles[i]++;
                }
            }

            //xử lý bug vụ nếu lỡ bị lỗi board rỗng
            if(pileCount == 0)
            {
                this.isGameOver = true;
            }
        }

        public void CreateRandom(int pilesCount, int min, int max)
        {
            this.pileCount = pilesCount;
            this.currentPlayer = false;
            this.isGameOver = false;

            piles = new int[pilesCount];

            random = new Random();

            for (int i = 0; i < pilesCount; i++)
            {

                piles[i] = random.Next(min, max + 1);
            }

            InitBoard();
        }

        public int GetMaxInPiles()
        {
            int max = 0;
            for (int i = 0; i < this.pileCount; i++)
            {
                if (this.piles[i] > max) max = this.piles[i];
            }
            return max;
        }
        public int[][] InitBoard()
        {
            int max = this.GetMaxInPiles();


            this.board = new int[this.pileCount][];

            for(int i =  0; i < this.pileCount; i++)
            {
                board[i] = new int[max];
            }

            for (int i = 0; i < pileCount; i++)
            {
                for (int j = 0; j < piles[i]; j++)
                {
                    board[i][j] = 0;
                }
                for (int j = piles[i]; j < max; j++)
                {
                    board[i][j] = -1;
                }
            }

            return board;
        }

        //tính lại số đống và số lượng mỗi đống còn lại từ board (sử dụng khi load game)
        public void RecalculatePiles(int[][] board)
        {
            this.pileCount = board.Length;

            for (int i = 0; i < board.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 0) count++;
                }
                piles[i] = count;
            }
        }

        public GameState Clone()
        {
            GameState stateClone = new GameState(this);

            return stateClone;
        }

    }
    
}
