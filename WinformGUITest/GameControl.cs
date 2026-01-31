using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinformGUITest
{
    public partial class GameControl : UserControl
    {
        private int iconSize = 40; // kích thước mỗi ô (icon)
        public GameControl()
        {
            this.BackColor = Color.Aquamarine;
            //MessageBox.Show(string.Format("{0}", .Width));
            InitializeComponent();
            CreateBoard(10, 10);
        }



        public void CreateBoard(int rows, int cols) //row với cols sẽ tuỳ thuộc vào pileCount
        {
            boardPanel.Controls.Clear();

            boardPanel.Width = (iconSize + 5) * cols;
            boardPanel.Height = (iconSize + 5) * rows;


            //boardPanel.Dock = DockStyle.Fill;
            //boardPanel.Anchor = AnchorStyles.None;

            boardPanel.Dock = DockStyle.Fill;
            boardPanel.Anchor = AnchorStyles.None;


            boardPanel.BorderStyle = BorderStyle.FixedSingle;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btn = new Button();

                    btn.Width = iconSize;
                    btn.Height = iconSize;

                    //btn.Text = string.Format("{0},{1}", i, j);
                    btn.Text = "";
                    btn.BackgroundImage = Image.FromFile(@"D:\Download\coin.png");
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.TabStop = false;

                    btn.Left = (iconSize + 5) * i;
                    btn.Top = (iconSize + 5) * j;

                    //btn.Padding = new Padding(10);

                    boardPanel.Controls.Add(btn);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
