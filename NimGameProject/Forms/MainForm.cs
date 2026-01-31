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

            menu.ButtonPVEClicked += GameForm_Load; //gọi GameForm

            menu.Show();
        }
        private void GameForm_Load()
        {
            GameForm game = new GameForm();

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
