namespace TestGUIForm
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            pveButton = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(pveButton, 1, 3);
            tableLayoutPanel1.Controls.Add(button1, 1, 5);
            tableLayoutPanel1.Controls.Add(button2, 1, 7);
            tableLayoutPanel1.Controls.Add(button3, 1, 9);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 14;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(600, 800);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(184, 25);
            label1.Name = "label1";
            label1.Size = new Size(232, 57);
            label1.TabIndex = 0;
            label1.Text = "NIM GAME";
            // 
            // pveButton
            // 
            pveButton.BackgroundImage = (Image)resources.GetObject("pveButton.BackgroundImage");
            pveButton.BackgroundImageLayout = ImageLayout.Zoom;
            pveButton.Dock = DockStyle.Fill;
            pveButton.FlatAppearance.BorderSize = 0;
            pveButton.FlatStyle = FlatStyle.Flat;
            pveButton.Font = new Font("FVF Fernando 08", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pveButton.Location = new Point(123, 159);
            pveButton.Name = "pveButton";
            pveButton.Size = new Size(354, 62);
            pveButton.TabIndex = 1;
            pveButton.Text = "PvP";
            pveButton.UseVisualStyleBackColor = true;
            pveButton.Click += pveButton_Click;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Dock = DockStyle.Fill;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("FVF Fernando 08", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(123, 247);
            button1.Name = "button1";
            button1.Size = new Size(354, 62);
            button1.TabIndex = 2;
            button1.Text = "PvP";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.Dock = DockStyle.Fill;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("FVF Fernando 08", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(123, 335);
            button2.Name = "button2";
            button2.Size = new Size(354, 62);
            button2.TabIndex = 3;
            button2.Text = "PvP";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.Dock = DockStyle.Fill;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("FVF Fernando 08", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(123, 423);
            button3.Name = "button3";
            button3.Size = new Size(354, 62);
            button3.TabIndex = 4;
            button3.Text = "PvP";
            button3.UseVisualStyleBackColor = true;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 800);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            Text = "MenuForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button pveButton;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}