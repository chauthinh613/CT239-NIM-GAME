using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimGameProject
{
    public class Effect
    {
        public static void ApplyTextboxHoverEffect(Button button)
        {
            button.BackgroundImage = Properties.Resources.textbox_background;
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            //hông bị nền xám xám của cái mặc định
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            //button.UseVisualStyleBackColor = false;

            button.Cursor = Cursors.Hand;

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

        public enum ButtonType{
            home,
            restart,
            undo,
            help,
        }
        /// type
        /// home, restart, undo, sound
        /// 
        public static void ApplyButtonHoverEffect(Button button, ButtonType type)
        {
            string normalName = $"button_{type}";
            string hoverName = $"button_{type}_hover";

            var normalImage = (Image)Properties.Resources.ResourceManager.GetObject(normalName);
            var hoverImage = (Image)Properties.Resources.ResourceManager.GetObject(hoverName);

            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            button.Cursor = Cursors.Hand;

            //hông bị nền xám xám của cái mặc định
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button.MouseEnter += (s, e) =>
            {
                button.BackgroundImage = hoverImage;
            };
            button.MouseLeave += (s, e) =>
            {
                button.BackgroundImage = normalImage;
            };
        }
    }
}
