using TestLogic;
using System.Media;

namespace TestGUIForm
{
    public partial class GameForm : Form
    {
        //thử 
        public event Action GameOver;
        //âm thanh lụm xu
        SoundPlayer coinCollect = new SoundPlayer(@"D:\Download\mario-coin-sound-effect.wav");
        SoundPlayer switchPlayer = new SoundPlayer(@"D:\Download\mixkit-on-or-off-light-switch-tap-2585.wav");
        SoundPlayer winnerSound = new SoundPlayer(@"D:\Download\mixkit-video-game-win-2016.wav");
        SoundPlayer biteSound = new SoundPlayer(@"D:\Download\carrotnom-92106.wav");

        private int caroSize = 50;
        MainGame game;
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            InitGame();
        }

        public void InitGame()
        {
            game = new MainGame(5, 1, 10);
            int max = 0;
            for (int i = 0; i < game.PilesCount; i++)
            {
                if (max < game.Piles[i]) max = game.Piles[i];
            }
            CreateBoardBackground(game.PilesCount, max, game.Piles);


            player1Button.Enabled = true;
            player2Button.Enabled = false;
            if (player1Button.Enabled)
            {
                player2Button.Margin = new Padding(10);
                player1Button.Margin = new Padding(0);
            }
            else
            {
                player2Button.Margin = new Padding(0);
                player1Button.Margin = new Padding(10);
            }

        }
        public void CreateBoardBackground(int rows, int cols, int[] piles)
        {
            boardPanel.Controls.Clear();
            boardPanel.Anchor = AnchorStyles.None;
            boardPanel.Size = new Size(cols * caroSize, rows * caroSize);
            //boardPanel.BorderStyle = BorderStyle.FixedSingle;

            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                count++;
                for (int j = 0; j < cols; j++)
                {
                    Panel caro = new Panel();
                    caro.Size = new Size(caroSize, caroSize);

                    if ((i + j) % 2 == 0) caro.BackColor = Color.LightGoldenrodYellow;
                    else caro.BackColor = Color.LightYellow;
                    caro.Location = new Point(j * caroSize, i * caroSize);

  

                    //quan trọng
                    if (j < piles[i])
                    {
                        string path = "";
                        if (count == 3) path = @"D:\Download\carrot.png";
                        else if (count == 4) path = @"D:\Download\avocado.png";
                        else if (count == 1) path = @"D:\Download\cherry.png";
                        else if (count == 2) path = @"D:\Download\mango.png";
                        else path = @"D:\Download\apple.png";
                        caro.Controls.Add(CreateCoinButton(i, j, path));
                    }

                    boardPanel.Controls.Add(caro);
                }
            }
        }


        public Button CreateCoinButton(int i, int j, string path)
        {
            Button coin = new Button();

            coin.Size = new Size(40, 40);
            coin.Location = new Point(5, 5);


            //coin.Anchor = AnchorStyles.None;
            //coin.Dock = DockStyle.Fill;

            coin.BackgroundImage = Image.FromFile(path);
            coin.BackgroundImageLayout = ImageLayout.Zoom;
            coin.FlatAppearance.BorderSize = 0;
            coin.FlatStyle = FlatStyle.Flat;

            coin.Text = "";

            //quan trọng
            coin.Tag = new Point(i, j);

            coin.Click += Coin_Click;

            return coin;
        }



        private bool inTurnCheck;
        private int chosenPile;
        private int chosenItems;
        private void Coin_Click(object? sender, EventArgs e)
        {
            Button coin = sender as Button;

            //coin.Parent.Controls.Remove(coin);
            //coin.Dispose();

            Point position = (Point)coin.Tag;
            //coinCollect.Play();
            biteSound.Play();

            if (!inTurnCheck)
            {
                inTurnCheck = true;
                chosenPile = position.X + 1;


            }

            if (!CheckInPile(position.X + 1))
            {
                MessageBox.Show("Vui long chon chung 1 hang!");
            }
            else
            {
                chosenItems += 1;
                coin.Visible = false;
                if (chosenItems == game.Piles[position.X]) FinishTurn();
            }

            //nhận diện lại vị trí


            //phải kiểm tra chung hàng hay không
            //game.MakeMove(position.X + 1, 1);


        }

        private bool CheckInPile(int position)
        {
            if (inTurnCheck)
            {
                if (chosenPile != position) return false;
            }
            return true;
        }

        private void TestMessage(string test)
        {
            string mess = test;
            for (int i = 0; i < game.PilesCount; i++)
            {
                mess += game.Piles[i].ToString() + "\n";
            }

            MessageBox.Show(mess);
        }

        private void TestEndGame()
        {
            string win = "";
            if (!game.CurrentPlayer)
                win = string.Format("Nguoi choi Cho thang");
            else
                win = string.Format("Nguoi choi Meo thang");

            winnerSound.Play();
            MessageBox.Show(win);

            GameOver?.Invoke();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void finishTurn_Click(object sender, EventArgs e)
        {
            if (chosenItems != 0)
            {
                FinishTurn();
                
            }
        }

        private void FinishTurn()
        {
            game.MakeMove(chosenPile, chosenItems);
            inTurnCheck = false;
            chosenPile = 0;
            chosenItems = 0;

            ControlChange();

            if (!game.IsGameOver)
            {
                //string test = string.Format("Toi luot nguoi choi {1}, Chon hang {0}\n", chosenPile, game.CurrentPlayer);
                //TestMessage(test);
            }
            else TestEndGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chosenItems != 0)
            {
                FinishTurn();
                
            }

        }

        private void ControlChange()
        {
            player2Button.Enabled = !player2Button.Enabled;
            player1Button.Enabled = !player1Button.Enabled;

            switchPlayer.Play();

            if (player1Button.Enabled)
            {
                player2Button.Margin = new Padding(10);
                player2Button.BackgroundImage = Image.FromFile(@"D:\Download\cat_unable.png");
                player1Button.Margin = new Padding(0);
            }
            else
            {
                player2Button.Margin = new Padding(0);
                player1Button.Margin = new Padding(10);
                player2Button.BackgroundImage = Image.FromFile(@"D:\Download\cat.png");
            }
        }
    }
}
