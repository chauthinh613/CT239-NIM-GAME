using NimGameProject.GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace NimGameProject.Forms
{
    public partial class GameForm : Form
    {
        string player2EnableImagePath;
        string player2UnableImagePath;

        GameEngine game;

        GameState gameInit; //lưu trạng thái đầu tiên của game để có gì reset

        public event Action ExitToMenu;

        private int caroSize;
        private int itemSize;

        private bool isPVP;
        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(bool isPVP)
        {
            InitializeComponent();
            this.isPVP = isPVP;

            if (isPVP)
            {
                player2EnableImagePath = @"D:\Download\cat.png";
                player2UnableImagePath = @"D:\Download\cat_unable.png";
            }
            else
            {
                player2EnableImagePath = @"D:\Download\computer.png";
                player2UnableImagePath = @"D:\Download\computer_unable.png";
            }

        }

        private void InitGame()
        {
            AdjustSize(game.GameState.PilesCount, game.GameState.GetMaxInPiles());

            game.SwitchPlayerEvent += AdjustPlayerButton;
            game.GameOverEvent += GameOver;
            game.ChosenPileEvent += RowSelectedEffect;
            game.ComputerMoveEvent += ComputerMove;
            game.ResetRowEffectEvent += ResetRowEffect;

            InitGameBoard();
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            game = new GameEngine(isPVP, true, new GameState(8,1,8));

            gameInit = game.GameState.CloneGameState();


            InitGame();

        }

        public void AdjustSize(int pilesCount, int max) //chỉnh kích thước nếu ít thì cho bự, nhiều thì cho nhỏ lại
        {
            if(pilesCount <= 7 && max <= 7)
            {
                caroSize = 50;
                itemSize = 40;
            }
            else
            {
                caroSize = 42;
                itemSize = 32;
            }
        }

        public void GameOver()
        {
            ExitToMenu?.Invoke();
        }

        public void InitGameBoard()
        {

            int rows = game.Board.GetLength(0);
            int cols = game.Board.GetLength(1);

            CreateBoardBackground(rows,cols);

            AdjustPlayerButton();
        }
        public void CreateBoardBackground(int rows, int cols)
        {
            panelBoard.Controls.Clear();
            panelBoard.Anchor = AnchorStyles.None;
            panelBoard.Size = new Size(cols * caroSize, rows * caroSize);
            //panelBoard.BorderStyle = BorderStyle.FixedSingle;


            int count = 1;

            for (int i = 0; i < rows; i++)
            {

                Random r = new Random();
                int t = r.Next(1, 8 + 1);
                if (t == count) t = (t % 8 + 1);
                count = t;

                for (int j = 0; j < cols; j++)
                {
                    Panel caro = new Panel();
                    caro.Size = new Size(caroSize, caroSize);

                    if ((i + j) % 2 == 0) caro.BackColor = Color.LightGoldenrodYellow;
                    else caro.BackColor = Color.LightYellow;
                    caro.Location = new Point(j * caroSize, i * caroSize);

                    caro.Tag = new Point(i, j);

                    //quan trọng
                    if (game.Board[i,j] == 0)
                    {
                        string path = ImagePathRandom(count);
                        caro.Controls.Add(CreateItemButton(i, j, path));
                    }

                    panelBoard.Controls.Add(caro);
                }
            }
        }

        public String ImagePathRandom(int count)
        {
            string path = "";
            switch (count)
            {
                case 1: path = @"D:\Download\carrot.png"; break;
                case 2: path = @"D:\Download\avocado.png"; break;
                case 3: path = @"D:\Download\cherry.png"; break;
                case 4: path = @"D:\Download\mango.png"; break;
                case 5: path = @"D:\Download\mangosteen.png"; break;
                case 6: path = @"D:\Download\watermelon.png"; break;
                case 7: path = @"D:\Download\blueberry.png"; break;
                default: path = @"D:\Download\apple.png"; break;
            }
            

            return path;
        }


        public Button CreateItemButton(int i, int j, string path)
        {
            Button item = new Button();

            item.Size = new Size(itemSize, itemSize);
            item.Location = new Point(5, 5); //(caroSize - itemSize)/2


            //item.Anchor = AnchorStyles.None;
            //item.Dock = DockStyle.Fill;

            item.BackgroundImage = Image.FromFile(path);
            item.BackgroundImageLayout = ImageLayout.Zoom;
            item.FlatAppearance.BorderSize = 0;
            item.FlatStyle = FlatStyle.Flat;

            item.Text = "";

            //quan trọng
            item.Tag = new Point(i, j);


            item.Click += Item_Click;
            item.MouseEnter += Enter_Effect;
            item.MouseLeave += Leave_Effect;

            return item;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            if (!game.IsPVP && game.GameState.CurrentPlayer) return;

            Button item = sender as Button;

            Point point = (Point)item.Tag;

            int i = (int)point.X;
            int j = (int)point.Y;


            if (game.ChosenItem(i, j, game.GameState.CurrentPlayer))
            {
                //RowSelectedEffect(i);
                item.Visible = false;
            }
            else
            {
                MessageBox.Show("Hãy chọn chung 1 hàng");
            }
        }
        private void Enter_Effect(object sender, EventArgs e)
        {
            Button item = sender as Button;

            //selectItems.Play();
            item.Size = new Size(caroSize, caroSize);
            item.Location = new Point(0, 0);
        }

        private void Leave_Effect(object sender, EventArgs e)
        {
            Button item = sender as Button;

            item.Size = new Size(itemSize, itemSize);
            item.Location = new Point(5, 5);
        }

        private void RowSelectedEffect()
        {
            foreach (Control c in panelBoard.Controls)
            {
                Panel p = c as Panel;
                Point position = (Point)p.Tag;

                if (position.X == game.ChosenPile)
                {

                    if ((position.X + position.Y) % 2 == 0)
                    {
                        p.BackColor = Color.PaleTurquoise;
                    }
                    else
                    {
                        {
                            p.BackColor = Color.Honeydew;
                        }
                    }
                }
            }
        }

        private void ResetRowEffect()
        {
            int row = game.ChosenPile;

            foreach (Control c in panelBoard.Controls)
            {
                Panel p = c as Panel;
                Point position = (Point)p.Tag;

                if (position.X == row)
                {
                    if ((position.X + position.Y) % 2 == 0)
                    {
                        p.BackColor = Color.LightGoldenrodYellow;
                    }
                    else
                    {
                        {
                            p.BackColor = Color.LightYellow;
                        }
                    }
                }
            }
        }

        public void AdjustPlayerButton()
        { 
            if (!game.GameState.CurrentPlayer)
            {
                buttonPlayer1.Enabled = true;
                buttonPlayer2.Enabled = false;

                buttonPlayer2.Margin = new Padding(10);
                buttonPlayer2.BackgroundImage = Image.FromFile(player2UnableImagePath);
                buttonPlayer1.Margin = new Padding(0);
                buttonPlayer1.BackgroundImage = Image.FromFile(@"D:\Download\dog.png");
            }
            else
            {
                buttonPlayer1.Enabled = false;
                buttonPlayer2.Enabled = true;

                buttonPlayer2.Margin = new Padding(0);
                buttonPlayer1.Margin = new Padding(10);
                buttonPlayer2.BackgroundImage = Image.FromFile(player2EnableImagePath);
                buttonPlayer1.BackgroundImage = Image.FromFile(@"D:\Download\dog_unable.png");
            }
        }
        private void buttonPlayer1_Click(object sender, EventArgs e)
        {
            //ResetRowEffect();
            game.EndTurn();
            AdjustPlayerButton();

        }

        private void buttonPlayer2_Click(object sender, EventArgs e)
        {
            if (!isPVP) return; //hông kích hoạt đối với chơi với máy
            game.EndTurn();
            AdjustPlayerButton(); 
            //ResetRowEffect();
        }


        public async void ComputerMove()
        {

            var move = game.GetComputerMove();

            RowSelectedEffect();

            await AnimateComputerMove(move.piles, move.items);

            game.ApplyMove(move.piles, move.items);

            //ResetRowEffect(move.piles);
        }

        /// 
        /// không bị delay
        /// 
        //public void AnimateComputerMove(int piles, int items)
        //{
        //    int remove = 0;

        //    foreach(Control c in panelBoard.Controls)
        //    {
        //        Panel p = c as Panel;
        //        Point position = (Point)p.Tag; //mỗi ô caro

        //        if(position.X == piles)
        //        {
        //            foreach(Control btn in p.Controls)
        //            {
        //                if(btn is Button && btn.Visible)
        //                {
        //                    btn.Visible = false;

        //                    remove++;
        //                    if (remove == items) return;
        //                }
        //            }
        //        }
        //    }
        //}

        public async Task AnimateComputerMove(int pile, int items)
        {
            int remove = 0;

            foreach (Control c in panelBoard.Controls)
            {
                Panel p = c as Panel;
                Point position = (Point)p.Tag; //mỗi ô caro

                if (position.X == pile)
                {
                    foreach (Control btn in p.Controls)
                    {
                        if (btn is Button && btn.Visible)
                        {
                            btn.Visible = false;

                            await Task.Delay(200);

                            remove++;
                            if (remove == items) return;
                        }
                    }
                }
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            ExitToMenu.Invoke();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        public void ResetGame()
        {
            game = new GameEngine(isPVP, true, new GameState(gameInit));

            InitGame();

        }
    }
}
