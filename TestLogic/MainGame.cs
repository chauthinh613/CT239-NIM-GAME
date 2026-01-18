using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic
{
    internal class MainGame
    {
        private int pilesCount;
        private int[] piles;
        private bool currentPlayer; //false = player 1, true = player 2
        private bool isGameOver;

        public MainGame(int[] piles)
        {
            this.piles = piles;
            pilesCount = piles.Length;

            this.currentPlayer = false;
            this.isGameOver = false;
        }

        //sử dụng khi load game
        public MainGame(int[] piles, bool currentPlayer)
        {
            this.piles = piles;
            this.currentPlayer = currentPlayer;

            this.isGameOver = false;
            this.pilesCount = piles.Length;
        }

        public MainGame(int pilesCount, int min, int max)
        {
            this.pilesCount= pilesCount;

            RandomGame(min,max);

            this.currentPlayer = false;
            this.isGameOver = false;
        }

        public void RandomGame(int min, int max)
        {
            piles = new int[pilesCount];
            //tạo random
            Random random = new Random();
            for (int i = 0; i < this.pilesCount; i++)
            {
                this.piles[i] = random.Next(min, max);
            }
        }

        public void PrintGame()
        {
            //in thông tin lượt chơi
            if (!currentPlayer)
                Console.WriteLine("-- Nguoi choi 1 -- ");
            else 
                Console.WriteLine("-- Nguoi choi 2 -- ");
            //in đống và đồ vật
            for (int i = 0; i < this.pilesCount; i++)
                {
                Console.Write("{0} (so luong: {1}) : ", i + 1, piles[i]);
                    for (int j = 0; j < this.piles[i]; j++)
                    {
                        Console.Write("O ");
                    }
                    Console.WriteLine();
                }
        }

        public bool checkGameOver()
        {
            for(int i = 0; i < this.pilesCount; i++)
            {
                if (piles[i] > 0) return false;
            }
            return true;
        }

        public void removeItems(int chosenPile, int chosenItems)
        {
            piles[chosenPile - 1] -= chosenItems;
        }
        public void Process() //sử dụng để test trên console
        {
            //khởi tạo trò chơi
            //InitGame();

            int chosenItems;
            int chosenPile;

            do
            {
                Console.Clear();

                PrintGame();

                Console.Write("Chon mot hang: ");
                chosenPile = int.Parse(Console.ReadLine());

                Console.Write("Chon so luong: ");
                chosenItems = int.Parse(Console.ReadLine());

                if(!validationCheck(chosenPile, chosenItems)) continue;

                removeItems(chosenPile, chosenItems);


                currentPlayer = !currentPlayer;

                isGameOver = checkGameOver();

            } while (!this.isGameOver);

            
            Console.Clear();
            PrintGame();

            Console.WriteLine("-------------------------");
            Console.WriteLine("Chuc mung nguoi choi {0} chien thang!", !currentPlayer);

        }

        //thay vì process thì dùng (nếu sử dụng cho winform
        public bool MakeMove(int chosenPile,  int chosenItems)
        {
            if (isGameOver) return false;

            if (!validationCheck(chosenPile, chosenItems)) return false;

            removeItems(chosenPile, chosenItems);

            isGameOver = checkGameOver();
            
            if(!isGameOver)
                currentPlayer = !currentPlayer;

            return true;

        }

        //hàm checkValid: kiểm tra giá trị nhập có hợp lệ hay không
        public bool validationCheck(int chosenPile, int chosenItems)
        {
            int chosenPileIndex = chosenPile - 1;
            
            if (chosenPileIndex < 0 || chosenPile > this.pilesCount) return false;
            if (piles[chosenPileIndex] <= 0) return false;
            if (chosenItems <= 0 || chosenItems > this.piles[chosenPileIndex]) return false;

            return true;
        }

        public static void Main(string[] args)
        {
            int[] piles = new int[] { 5, 6, 1 };
            MainGame game = new MainGame(piles, true);
            game.Process();
        }
    }
}
