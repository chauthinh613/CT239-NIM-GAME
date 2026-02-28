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
        public MenuForm()
        {
            InitializeComponent();

            ApplyHoverEffect(buttonPVE);
            ApplyHoverEffect(buttonPVP);
            ApplyHoverEffect(buttonHistory);
            ApplyHoverEffect(buttonSetting);
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

        //thêm hiệu ứng hover cho button
        private void ApplyHoverEffect(Button button)
        {
            button.BackgroundImage = Properties.Resources.textbox_background;
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            //hông bị nền xám xám của cái mặc định
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            //button.UseVisualStyleBackColor = false;

            button.MouseEnter += (s, e) =>
            {
                button.BackgroundImage = Properties.Resources.textbox_background_hover;
                button.ForeColor = Color.SandyBrown;
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackgroundImage = Properties.Resources.textbox_background;
                button.ForeColor = Color.SaddleBrown;
            };
        }
    }
}
