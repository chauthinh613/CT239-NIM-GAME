namespace TestGUIForm
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            boardPanel = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            player1Button = new Button();
            player2Button = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Info;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(boardPanel, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(582, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // boardPanel
            // 
            boardPanel.Anchor = AnchorStyles.None;
            boardPanel.Location = new Point(166, 295);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(250, 125);
            boardPanel.TabIndex = 0;
            boardPanel.Paint += boardPanel_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(player1Button, 1, 0);
            tableLayoutPanel2.Controls.Add(player2Button, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 628);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(576, 100);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // player1Button
            // 
            player1Button.BackgroundImage = (Image)resources.GetObject("player1Button.BackgroundImage");
            player1Button.BackgroundImageLayout = ImageLayout.Zoom;
            player1Button.Dock = DockStyle.Fill;
            player1Button.FlatAppearance.BorderSize = 0;
            player1Button.FlatStyle = FlatStyle.Flat;
            player1Button.Location = new Point(161, 3);
            player1Button.Name = "player1Button";
            player1Button.Size = new Size(114, 94);
            player1Button.TabIndex = 2;
            player1Button.TabStop = false;
            player1Button.UseVisualStyleBackColor = true;
            player1Button.Click += finishTurn_Click;
            // 
            // player2Button
            // 
            player2Button.BackgroundImage = (Image)resources.GetObject("player2Button.BackgroundImage");
            player2Button.BackgroundImageLayout = ImageLayout.Zoom;
            player2Button.Dock = DockStyle.Fill;
            player2Button.FlatAppearance.BorderSize = 0;
            player2Button.FlatStyle = FlatStyle.Flat;
            player2Button.Location = new Point(301, 3);
            player2Button.Name = "player2Button";
            player2Button.Size = new Size(114, 94);
            player2Button.TabIndex = 3;
            player2Button.TabStop = false;
            player2Button.UseVisualStyleBackColor = true;
            player2Button.Click += button1_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(button4, 4, 0);
            tableLayoutPanel3.Controls.Add(button3, 3, 0);
            tableLayoutPanel3.Controls.Add(button2, 2, 0);
            tableLayoutPanel3.Controls.Add(button1, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 23);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(576, 65);
            tableLayoutPanel3.TabIndex = 2;
            tableLayoutPanel3.Paint += tableLayoutPanel3_Paint_1;
            // 
            // button4
            // 
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Zoom;
            button4.Dock = DockStyle.Fill;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(363, 3);
            button4.Name = "button4";
            button4.Size = new Size(66, 59);
            button4.TabIndex = 3;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.Dock = DockStyle.Fill;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(291, 3);
            button3.Name = "button3";
            button3.Size = new Size(66, 59);
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.Dock = DockStyle.Fill;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(219, 3);
            button2.Name = "button2";
            button2.Size = new Size(66, 59);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Dock = DockStyle.Fill;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(147, 3);
            button1.Name = "button1";
            button1.Size = new Size(66, 59);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 753);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameForm";
            Text = "GameForm";
            Load += GameForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel boardPanel;
        private TableLayoutPanel tableLayoutPanel2;
        private Button player1Button;
        private Button player2Button;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button4;
    }
}