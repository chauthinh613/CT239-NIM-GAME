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
    public partial class MenuForm : Form
    {
        public event Action ButtonPVEClicked;
        public event Action ButtonPVPClicked;
        public event Action ButtonHistoryClicked;
        public event Action ButtonSettingClicked;
        public MenuForm()
        {
            InitializeComponent();

            Effect.ApplyTextboxHoverEffect(buttonPVE);
            Effect.ApplyTextboxHoverEffect(buttonPVP);
            Effect.ApplyTextboxHoverEffect(buttonHistory);
            Effect.ApplyTextboxHoverEffect(buttonSetting);
        }

        private void buttonPVE_Click(object sender, EventArgs e)
        {
            ButtonPVEClicked.Invoke();
        }

        private void buttonPVP_Click(object sender, EventArgs e)
        {
            ButtonPVPClicked.Invoke();
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            ButtonHistoryClicked.Invoke();
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            ButtonSettingClicked.Invoke();
        }
    }
}
