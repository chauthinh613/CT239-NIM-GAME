using NimGameProject.GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimGameProject.Forms
{
    public partial class GameForm : Form
    {
        GameEngine game;
        public event Action ExitToMenu;

        private int caroSize = 48;
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            game = new GameEngine(true, false, new GameState(3, 1, 3));

            game.SwitchPlayerEvent += AdjustPlayerButton;
            game.GameOverEvent += GameOver;

            InitGame();

        }

        public void GameOver()
        {
            ExitToMenu?.Invoke();
        }

        public void InitGame()
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
                int t = r.Next(1, 5 + 1);
                if (t == count) t = (t % 5 + 1);
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
                        string path = "";

                        if (count == 3) path = @"D:\Download\carrot.png";
                        else if (count == 4) path = @"D:\Download\avocado.png";
                        else if (count == 1) path = @"D:\Download\cherry.png";
                        else if (count == 2) path = @"D:\Download\mango.png";
                        else path = @"D:\Download\apple.png";
                        caro.Controls.Add(CreateItemButton(i, j, path));
                    }

                    panelBoard.Controls.Add(caro);
                }
            }
        }


        public Button CreateItemButton(int i, int j, string path)
        {
            Button item = new Button();

            item.Size = new Size(38, 38);
            item.Location = new Point(5, 5);


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
            Button item = sender as Button;

            Point point = (Point)item.Tag;

            int i = (int)point.X;
            int j = (int)point.Y;


            if (game.ChosenItem(i, j, game.GameState.CurrentPlayer))
            {
                RowSelectedEffect(i);
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
            item.Size = new Size(46, 46);
            item.Location = new Point(1, 1);
        }

        private void Leave_Effect(object sender, EventArgs e)
        {
            Button item = sender as Button;

            item.Size = new Size(38, 38);
            item.Location = new Point(5, 5);
        }

        private void RowSelectedEffect(int row)
        {
            foreach (Control c in panelBoard.Controls)
            {
                Panel p = c as Panel;
                Point position = (Point)p.Tag;

                if (position.X == row)
                {
                    if (p.BackColor == Color.LightGoldenrodYellow)
                    {
                        p.BackColor = Color.PaleTurquoise;
                    }
                    if (p.BackColor == Color.LightYellow)
                    {
                        {
                            p.BackColor = Color.Honeydew;
                        }
                    }
                }
            }
        }

        private void ResetRowEffect(int row)
        {
            MessageBox.Show("ủa");
            foreach (Control c in panelBoard.Controls)
            {
                Panel p = c as Panel;
                Point position = (Point)p.Tag;

                if (position.X == row)
                {
                    if (p.BackColor == Color.PaleTurquoise)
                    {
                        p.BackColor = Color.LightGoldenrodYellow;
                    }
                    if (p.BackColor == Color.Honeydew)
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
            ResetRowEffect(game.ChosenPile);

            if (!game.GameState.CurrentPlayer)
            {
                buttonPlayer1.Enabled = true;
                buttonPlayer2.Enabled = false;

                buttonPlayer2.Margin = new Padding(10);
                buttonPlayer2.BackgroundImage = Image.FromFile(@"D:\Download\cat_unable.png");
                buttonPlayer1.Margin = new Padding(0);
                buttonPlayer1.BackgroundImage = Image.FromFile(@"D:\Download\dog.png");
            }
            else
            {
                buttonPlayer1.Enabled = false;
                buttonPlayer2.Enabled = true;

                buttonPlayer2.Margin = new Padding(0);
                buttonPlayer1.Margin = new Padding(10);
                buttonPlayer2.BackgroundImage = Image.FromFile(@"D:\Download\cat.png");
                buttonPlayer1.BackgroundImage = Image.FromFile(@"D:\Download\dog_unable.png");
            }
        }
        private void buttonPlayer1_Click(object sender, EventArgs e)
        {
            game.EndTurn();
            AdjustPlayerButton();
        }

        private void buttonPlayer2_Click(object sender, EventArgs e)
        {
            game.EndTurn();
            AdjustPlayerButton();
        }

    }
}
