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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            GameForm game = new GameForm(isPVP);

            game.Dock = DockStyle.Fill;
            game.TopLevel = false;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(game);
            panelMain.BackColor = Color.LightYellow;

            game.ExitToMenu += MenuForm_Load;

            game.Show();
        }
    }
}
