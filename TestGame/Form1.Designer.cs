namespace TestGame
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            numericUpDown1 = new NumericUpDown();
            panelMain = new Panel();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(57, 541);
            panel1.Name = "panel1";
            panel1.Size = new Size(333, 135);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.Location = new Point(367, 682);
            button1.Name = "button1";
            button1.Size = new Size(154, 59);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = Properties.Resources.logo_hoi_sinh_vien_inkythuatso_01;
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.Location = new Point(385, 481);
            button2.Name = "button2";
            button2.Size = new Size(195, 195);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BorderStyle = BorderStyle.None;
            numericUpDown1.Location = new Point(207, 702);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(154, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // panelMain
            // 
            panelMain.Location = new Point(44, 32);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(468, 416);
            panelMain.TabIndex = 4;
            panelMain.Paint += panelMain_Paint;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 753);
            Controls.Add(panelMain);
            Controls.Add(numericUpDown1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximumSize = new Size(600, 800);
            MinimumSize = new Size(600, 800);
            Name = "mainForm";
            Text = "Form1";
            Load += mainForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button button2;
        private NumericUpDown numericUpDown1;
        private Panel panelMain;
    }
}
