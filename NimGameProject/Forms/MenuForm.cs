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
        public MenuForm()
        {
            InitializeComponent();
        }

        private void buttonPVE_Click(object sender, EventArgs e)
        {
            ButtonPVEClicked.Invoke();
        }

        private void buttonPVP_Click(object sender, EventArgs e)
        {
            ButtonPVPClicked.Invoke();
        }
    }
}
