using NimGameProject.Engine;
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
                    pictureWinner.Image = Properties.Resources.button_dog;
                }
                else
                {
                    pictureWinner.Image = Properties.Resources.button_cat;
                }
            }
            else
            {
                if (!winnerPlayer)
                {
                    pictureWinner.Image = Properties.Resources.button_dog;
                }
                else
                {
                    pictureWinner.Image = Properties.Resources.button_computer;
                }
            }

            EffectManager.ApplyButtonHoverEffect(buttonHome, EffectManager.ButtonType.home);
            EffectManager.ApplyButtonHoverEffect(buttonRestart, EffectManager.ButtonType.restart);

            SoundManager.PlaySoundWin();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            ExitToMenu.Invoke();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            RestartGame.Invoke();
        }

        private void EndGameForm_Load(object sender, EventArgs e)
        {
        }
    }
}
