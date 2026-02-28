using NimGameProject.GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimGameProject.Forms
{
    public partial class MainForm : Form
    {
        GameConfig config = new GameConfig();
        public MainForm()
        {
            InitializeComponent();


        }


        /// <summary>
        /// hông cho màn hình bị giật giật khi load form khác
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // WS_EX_COMPOSITED, vẽ các control con trong một bộ đệm duy nhất
                cp.ExStyle |= 0x02000000; 
                return cp;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MenuForm_Load();
        }

        private void MenuForm_Load()
        {
            MenuForm menu = new MenuForm();

            menu.Dock = DockStyle.Fill;
            menu.TopLevel = false;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(menu);


            menu.ButtonPVEClicked += GameFormPVE; //gọi GameForm sẽ cài đặt máy chơi
            menu.ButtonPVPClicked += GameFormPVP; //gọi GameForm sẽ cài đặt 
            menu.ButtonHistoryClicked += HistoryForm_Load; //gọi HistoryForm sẽ cài đặt lịch sử chơi

            menu.Show();
        }

        private void GameFormPVP()
        {
            GameForm_Load(true);
        }

        private void GameFormPVE()
        {
            GameForm_Load(false);
        }

        private void GameForm_Load(bool isPVP)
        {
            GameForm game = new GameForm(isPVP, config);

            game.Dock = DockStyle.Fill;
            game.TopLevel = false;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(game);
            panelMain.BackColor = Color.LightYellow;

            game.ExitToMenu += MenuForm_Load;
            game.ShowEndGameForm += (result) =>
            {
                EndGameForm_Load(result.isPVP, result.winnerPlayer);
            };

            game.Show();
        }

        private void GameForm_Load(SaveData data, string filePath)
        {
            GameForm game = new GameForm(data, filePath);

            game.Dock = DockStyle.Fill;
            game.TopLevel = false;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(game);

            game.ExitToMenu += MenuForm_Load;
            game.ShowEndGameForm += (result) =>
            {
                EndGameForm_Load(result.isPVP, result.winnerPlayer);
            };
            game.Show();
        }

        private void SettingSaved(GameConfig config)
        {
            this.config = config;
        }

        private void HistoryForm_Load()
        {
            HistoryForm history = new HistoryForm();
            history.Dock = DockStyle.Fill;
            history.TopLevel = false;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(history);

            history.ExitToMenu += MenuForm_Load;
            history.HistoryButtonClicked += (data) =>
            {
                GameForm_Load(data.saveData, data.fullPath);
            };

            history.Show();
        }

        private void EndGameForm_Load(bool isPVP, bool winnerPlayer)
        {
            EndGameForm endForm = new EndGameForm(isPVP, winnerPlayer);
            endForm.Dock = DockStyle.Fill;
            endForm.TopLevel = false;

            endForm.ExitToMenu += MenuForm_Load;

            if (isPVP)
            {
                endForm.RestartGame += GameFormPVP;
            }
            else
            {
                endForm.RestartGame += GameFormPVE;
            }

                panelMain.Controls.Clear();
            panelMain.Controls.Add(endForm);

            endForm.Show();
        }
    }
}
