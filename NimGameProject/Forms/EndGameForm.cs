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
        public EndGameForm()
        {
            InitializeComponent();
        }

        public EndGameForm(bool isPVP, bool winnerPlayer)
        {
            InitializeComponent();

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
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {

        }
    }
}
