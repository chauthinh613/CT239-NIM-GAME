namespace WinformGUITest
{
    partial class MenuControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            pvpButton = new Button();
            pveButton = new Button();
            button3 = new Button();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(pvpButton, 1, 3);
            tableLayoutPanel1.Controls.Add(pveButton, 1, 5);
            tableLayoutPanel1.Controls.Add(button3, 1, 7);
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(550, 700);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pvpButton
            // 
            pvpButton.Location = new Point(113, 213);
            pvpButton.Name = "pvpButton";
            pvpButton.Size = new Size(324, 64);
            pvpButton.TabIndex = 0;
            pvpButton.Text = "Chơi Với Người";
            pvpButton.UseVisualStyleBackColor = true;
            pvpButton.Click += pvpButton_Click;
            // 
            // pveButton
            // 
            pveButton.Location = new Point(113, 353);
            pveButton.Name = "pveButton";
            pveButton.Size = new Size(324, 64);
            pveButton.TabIndex = 1;
            pveButton.Text = "Chơi Với Máy";
            pveButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(113, 493);
            button3.Name = "button3";
            button3.Size = new Size(324, 64);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(159, 76);
            label1.Name = "label1";
            label1.Size = new Size(232, 57);
            label1.TabIndex = 3;
            label1.Text = "NIM GAME";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MenuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "MenuControl";
            Size = new Size(550, 700);
            Load += MenuControl_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Button pvpButton;
        private Button pveButton;
        private Button button3;
        private Label label1;
    }
}
