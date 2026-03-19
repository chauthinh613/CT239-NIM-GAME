using NimGameProject.GameLogic;
using NimGameProject.Properties;
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

        Image player2EnableImage;
        Image player2UnableImage;

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

        private bool isChange; //có thay đổi mới hiển thị thông báo lưu game

        public GameForm()
        {
            InitializeComponent();
        }

        public GameForm(bool isPVP, GameConfig config)
        {
            InitializeComponent();
            this.isPVP = isPVP;

            InitState(config);

            isChange = false;
        }

        public GameForm(SaveData data, string path) //khỏi tạo từ game đã lưu
        {
            InitializeComponent();

            this.isPVP = data.IsPVP;
            this.game = new GameEngine(isPVP, true, new GameState(data.CurrentPlayer, data.Board));
            this.game.GameState.IsGameOver = data.IsGameOver;

            this.gameInit = new GameState( data.CurrentPlayer, data.Board);

            this.currentFilePath = path;

            /// nhớ check gameover (bị bug nếu máy đang lấy mà lưu game ///

            isChange = false;
        }

        private void InitState(GameConfig config)
        {
            game = new GameEngine(isPVP, config);

            gameInit = game.GameState.CloneGameState(); //lưu trạng thái đầu tiên của game để có gì reset
        }

        private void InitGame()
        {
            AdjustSize(game.GameState.PilesCount, game.GameState.GetMaxInPiles());

            game.SwitchPlayerEvent += AdjustPlayerButton;
            game.GameOverEvent += GameOver;
            game.ChosenPileEvent += RowSelectedEffect;
            game.ComputerMoveEvent += ComputerMove;
            game.ResetRowEffectEvent += ResetRowEffect;

            if (isPVP)
            {
                player2EnableImage = Resources.player_cat;
                player2UnableImage = Resources.player_cat_unable;
            }
            else
            {
                player2EnableImage = Resources.player_computer;
                player2UnableImage = Resources.player_computer_unable;
            }

            InitGameBoard();
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            InitGame();

            Effect.ApplyButtonHoverEffect(buttonHome, Effect.ButtonType.home);
            Effect.ApplyButtonHoverEffect(buttonReset, Effect.ButtonType.restart);
            Effect.ApplyButtonHoverEffect(buttonHelp, Effect.ButtonType.help);
            Effect.ApplyButtonHoverEffect(buttonUndo, Effect.ButtonType.undo);
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

            List<int> itemOrder = Enumerable.Range(1, 10).ToList();
            Random r = new Random();
            itemOrder = itemOrder.OrderBy(item => r.Next()).ToList(); //trộn

            for (int i = 0; i < rows; i++)
            {
                int count = itemOrder[i % 10]; //mỗi lấy ra 1 cái từ cái trộn

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
                        Image image = ItemImage(count);
                        caro.Controls.Add(CreateItemButton(i, j, image));
                    }

                    panelBoard.Controls.Add(caro);
                }
            }
        }

        public Image ItemImage(int count)
        {
            Image itemImage;
            switch (count)
            {
                case 1: itemImage = Resources.item_apple; break;
                case 2: itemImage = Resources.item_avocado; break;
                case 3: itemImage = Resources.item_cherry; break;
                case 4: itemImage = Resources.item_blueberry; break;
                case 5: itemImage = Resources.item_carrot; break;
                case 6: itemImage = Resources.item_guava; break;
                case 7: itemImage = Resources.item_mango; break;
                case 8: itemImage = Resources.item_mangosteen; break;
                case 9: itemImage = Resources.item_peach; break;
                default: itemImage = Resources.item_watermelon; break;
            }
            
            return itemImage;
        }


        public Button CreateItemButton(int i, int j, Image image)
        {
            Button item = new Button();

            item.Size = new Size(itemSize, itemSize);
            item.Location = new Point(5, 5); //(caroSize - itemSize)/2

            item.BackgroundImage = image;
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
            isChange = true;

            if (!game.IsPVP && game.GameState.CurrentPlayer) return;

            Button item = sender as Button;

            Point point = (Point)item.Tag;

            int i = (int)point.X;
            int j = (int)point.Y;


            if (game.ChosenItem(i, j, game.GameState.CurrentPlayer))
            {
                //RowSelectedEffect(i);
                UpdateUndoButton();
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
                buttonPlayer2.BackgroundImage = player2UnableImage;
                buttonPlayer1.Margin = new Padding(0);
                buttonPlayer1.BackgroundImage = Resources.player_dog;
            }
            else
            {
                buttonPlayer1.Enabled = false;
                buttonPlayer2.Enabled = true;

                buttonPlayer2.Margin = new Padding(0);
                buttonPlayer1.Margin = new Padding(10);
                buttonPlayer2.BackgroundImage = player2EnableImage;
                buttonPlayer1.BackgroundImage = Resources.player_dog_unable;
            }

            UpdateUndoButton();
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
            //nếu có filePath và hông có thay đổi thì khỏi hiện
            // currentFilePath != null && !isChange
            if (isChange || currentFilePath == null )
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn lưu?", "Lưu", MessageBoxButtons.OKCancel);

                if (dialog == DialogResult.OK)
                {
                    SaveGame();
                }
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
            isChange = true;

            var move = game.GetComputerMove();

            RowSelectedEffect();

            await AnimateComputerMove(move.piles, move.items);

            game.ApplyMove(move.piles, move.items);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LUẬT CHƠI NIM\n\r\n\r" +
                "- Mỗi lượt chỉ được chọn 1 hàng.\n\r" +
                "- Có thể lấy 1 hoặc nhiều vật phẩm trong hàng đó.\n\r" +
                "- Không được lấy ở nhiều hàng cùng lúc.\n\r" +
                "- Nhấn nút bên dưới để kết thúc lượt.\n\r" +
                "- Nếu lấy hết 1 hàng, lượt sẽ tự động kết thúc.\n\r\n\r" +
                "- Ai lấy vật phẩm cuối cùng là người thắng.");
        }

        private void panelBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateUndoButton()
        {
            bool canUndo = game.CanUndo();
            buttonUndo.Enabled = canUndo;
            buttonUndo.BackgroundImage = canUndo
                ? Resources.button_undo
                : Resources.button_undo_unable;
        }
        private void buttonUndo_Click(object sender, EventArgs e)
        {
            if (game.UndoInTurn())
            {
                RefreshBoard();
            }

            UpdateUndoButton();
        }

        private void RefreshBoard()
        {
            // Hiện lại item vừa undo trên UI
            foreach (Control c in panelBoard.Controls)
            {
                Panel p = c as Panel;
                Point pos = (Point)p.Tag;

                int i = pos.X, j = pos.Y;

                // Nếu board logic = 0 nhưng bị visible = false thì hiện lại
                if (game.Board[i][j] == 0)
                {
                    foreach (Control btn in p.Controls)
                    {
                        if (btn is Button)
                            btn.Visible = true;
                    }
                }
            }

            // Reset màu nếu không còn chọn hàng nào
            if (!game.InTurnCheck)
            {
                ResetRowEffect();
            }
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
            //int row = game.ChosenPile;

            foreach (Control c in panelBoard.Controls)
            {
                Panel p = c as Panel;
                Point position = (Point)p.Tag;

                //if (position.X == row)

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

        public async Task AnimateComputerMove(int pile, int items)
        {
            int remove = 0;

            //máy chơi thì hông có hiện undo
            buttonUndo.Enabled = false;
            buttonUndo.BackgroundImage = Resources.button_undo_unable;

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
    }
}
