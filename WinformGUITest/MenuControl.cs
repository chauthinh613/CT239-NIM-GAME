using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinformGUITest
{
    public partial class MenuControl : UserControl
    {
        public event Action PvPButtonClicked;
        public MenuControl()
        {

            this.BackColor = Color.Aqua;
            InitializeComponent();
        }

        private void pvpButton_Click(object sender, EventArgs e)
        {
            PvPButtonClicked?.Invoke();
        }

        private void MenuControl_Load(object sender, EventArgs e)
        {

        }
    }
}
