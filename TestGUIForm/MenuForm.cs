using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestGUIForm
{
    public partial class MenuForm : Form
    {
        public event Action pveButtonClicked;
        public MenuForm()
        {
            InitializeComponent();
        }

        private void pveButton_Click(object sender, EventArgs e)
        {
            pveButtonClicked?.Invoke();
        }
    }
}
