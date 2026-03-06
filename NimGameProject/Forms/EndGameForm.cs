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
    public partial class EndGameForm : Form
    {
        public event Action ExitToMenu;
        public event Action RestartGame;

        public EndGameForm()
        {
            InitializeComponent();
        }

        public EndGameForm(bool isPVP, bool winnerPlayer)
        {
            InitializeComponent();

            pictureWinner.SizeMode = PictureBoxSizeMode.Zoom;

            if (isPVP)
            {
                if (!winnerPlayer) 
                {
                    pictureWinner.Image = Image.FromFile(@"D:\Download\dog.png");
                }
                else
                {
                    pictureWinner.Image = Image.FromFile(@"D:\Download\cat.png");
                }
            }
            else
            {
                if (!winnerPlayer)
                {
                    pictureWinner.Image = Image.FromFile(@"D:\Download\dog.png");
                }
                else
                {
                    pictureWinner.Image = Image.FromFile(@"D:\Download\computer.png");
                }
            }

            Effect.ApplyButtonHoverEffect(buttonHome, Effect.ButtonType.home);
            Effect.ApplyButtonHoverEffect(buttonRestart, Effect.ButtonType.restart);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            ExitToMenu.Invoke();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            RestartGame.Invoke();
        }
    }
}
