using NimGameProject.GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using File = System.IO.File;

namespace NimGameProject.Forms
{
    public partial class GameForm : Form
    {
        const int numberFruits = 9;

        string player2EnableImagePath;
        string player2UnableImagePath;

        GameEngine game;

        GameState gameInit; //lưu trạng thái đầu tiên của game để có gì reset

        public event Action ExitToMenu;
        public event Action<(bool isPVP, bool winnerPlayer)> ShowEndGameForm;

        private int caroSize;
        private int itemSize;

        private bool isPVP;

        //lưu đường dẫn của file save hiện tại để có gì lưu đè lên đó hoặc là xoá luôn
        public string currentFilePath; 

        SaveManager saveManager = new SaveManager();

        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(bool isPVP, GameConfig config)
        {
            InitializeComponent();
            this.isPVP = isPVP;

            InitState(config);
        }
        public GameForm(bool isPVP)
        {
            InitializeComponent();
            this.isPVP = isPVP;
        }

        public GameForm(SaveData data, string path)
        {
            InitializeComponent();

            this.isPVP = data.IsPVP;
            this.game = new GameEngine(isPVP, true, new GameState(data.CurrentPlayer, data.Board));
            this.game.GameState.IsGameOver = data.IsGameOver;

            this.gameInit = new GameState( data.CurrentPlayer, data.Board);

            this.currentFilePath = path;

            /// nhớ check gameover (bị bug nếu máy đang lấy mà lưu game ///

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

        private void InitState(GameConfig config)
        {
            game = new GameEngine(isPVP, config);

            gameInit = game.GameState.CloneGameState(); //lưu trạng thái đầu tiên của game để có gì reset


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
            InitGame();

            Effect.ApplyButtonHoverEffect(buttonHome, Effect.ButtonType.home);
            Effect.ApplyButtonHoverEffect(buttonReset, Effect.ButtonType.restart);
            //Effect.ApplyButtonHoverEffect(buttonSave, "save");
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
            // nếu đang chơi từ file save thì xoá file đó
            if (!string.IsNullOrEmpty(currentFilePath) && File.Exists(currentFilePath))
            {
                File.Delete(currentFilePath);
                currentFilePath = null; // tránh xoá lần 2
            }

            ShowEndGameForm.Invoke((game.IsPVP, game.GameState.CurrentPlayer));
        }

        public void InitGameBoard()
        {

            int rows = game.Board.Length;
            int cols = game.Board[0].Length;

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
                int t = r.Next(1, 10 + 1);
                if (t == count) t = (t % 10 + 1);
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
                    if (game.Board[i][j] == 0)
                    {
                        string path = ImagePath(count);
                        caro.Controls.Add(CreateItemButton(i, j, path));
                    }

                    panelBoard.Controls.Add(caro);
                }
            }
        }

        public String ImagePath(int count)
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
                case 8: path = @"D:\Download\guava.png"; break;
                case 9: path = @"D:\Download\peach.png"; break;
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
            item.MouseEnter += Item_Enter_Effect;
            item.MouseLeave += Item_Leave_Effect;

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
        private void Item_Enter_Effect(object sender, EventArgs e)
        {
            Button item = sender as Button;

            //selectItems.Play();
            item.Size = new Size(caroSize, caroSize);
            item.Location = new Point(0, 0);
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

        private void buttonHome_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn lưu?", "Lưu", MessageBoxButtons.OKCancel);

            if(dialog == DialogResult.OK)
            {
                SaveGame();
            }

            ExitToMenu.Invoke();
        }

        private void SaveGame()
        {
            
            SaveData data = new SaveData();
            data.Board = game.Board;
            data.CurrentPlayer = game.GameState.CurrentPlayer;
            data.IsGameOver = game.GameState.IsGameOver;
            data.IsPVP = game.IsPVP;

            string newPath = saveManager.SaveGame(data);

            if(!string.IsNullOrEmpty(currentFilePath) && File.Exists(currentFilePath))
            {
                File.Delete(currentFilePath); //xoá file save cũ nếu có
            }

            currentFilePath = newPath; //cập nhật đường dẫn file save hiện tại
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


        public async void ComputerMove()
        {

            var move = game.GetComputerMove();

            RowSelectedEffect();

            await AnimateComputerMove(move.piles, move.items);

            game.ApplyMove(move.piles, move.items);

            //ResetRowEffect(move.piles);
        }

        /// ---- EFFECT ----///
        private void Item_Leave_Effect(object sender, EventArgs e)
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

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
    }
}
