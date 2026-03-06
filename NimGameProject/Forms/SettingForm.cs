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
    public partial class SettingForm : Form
    {

        GameConfig config = new GameConfig();
        public SettingForm()
        {
            InitializeComponent();

            DefaultShow();
        }

        public void DefaultShow(){
            textPilesCount.Enabled = false;
            textPilesCount.Text = config.Rows.ToString();
            textPilesCount.TextAlign = ContentAlignment.MiddleCenter;
            textPilesCount.Padding = new Padding(5, 0, 0, 0);
        }

        private void buttonMinusPiles_Click(object sender, EventArgs e)
        {
            config.Rows -= 1;
            if (config.Rows < 1) config.Rows = 1;

            textPilesCount.Text = config.Rows.ToString();
            textPilesCount.TextAlign = ContentAlignment.MiddleCenter;


        }

        private void buttonAddPiles_Click(object sender, EventArgs e)
        {
            config.Rows += 1;
            if( config.Rows > 10) config.Rows = 10;

            textPilesCount.Text = config.Rows.ToString();

        }
    }
}
