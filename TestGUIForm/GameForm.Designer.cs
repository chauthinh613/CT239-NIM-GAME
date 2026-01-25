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
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Info;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(boardPanel, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(582, 753);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // boardPanel
            // 
            boardPanel.Anchor = AnchorStyles.None;
            boardPanel.Location = new Point(166, 242);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(250, 125);
            boardPanel.TabIndex = 0;
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
            tableLayoutPanel2.Location = new Point(3, 593);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(576, 136);
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
            player1Button.Size = new Size(114, 130);
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
            player2Button.Size = new Size(114, 130);
            player2Button.TabIndex = 3;
            player2Button.TabStop = false;
            player2Button.UseVisualStyleBackColor = true;
            player2Button.Click += button1_Click;
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
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel boardPanel;
        private TableLayoutPanel tableLayoutPanel2;
        private Button player1Button;
        private Button player2Button;
    }
}