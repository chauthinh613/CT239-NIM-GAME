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
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            pvpButton = new Button();
            pveButton = new Button();
            button3 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(170, 142);
            label1.Name = "label1";
            label1.Size = new Size(274, 67);
            label1.TabIndex = 0;
            label1.Text = "NIM GAME";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(pvpButton, 1, 0);
            tableLayoutPanel1.Controls.Add(pveButton, 1, 2);
            tableLayoutPanel1.Controls.Add(button3, 1, 4);
            tableLayoutPanel1.Location = new Point(0, 240);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.Size = new Size(600, 292);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pvpButton
            // 
            pvpButton.Location = new Point(123, 3);
            pvpButton.Name = "pvpButton";
            pvpButton.Size = new Size(354, 42);
            pvpButton.TabIndex = 0;
            pvpButton.Text = "Chơi Với Người";
            pvpButton.UseVisualStyleBackColor = true;
            pvpButton.Click += pvpButton_Click;
            // 
            // pveButton
            // 
            pveButton.Location = new Point(123, 99);
            pveButton.Name = "pveButton";
            pveButton.Size = new Size(354, 42);
            pveButton.TabIndex = 1;
            pveButton.Text = "Chơi Với Máy";
            pveButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(123, 195);
            button3.Name = "button3";
            button3.Size = new Size(354, 42);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // MenuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            Name = "MenuControl";
            Size = new Size(600, 700);
            Load += MenuControl_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button pvpButton;
        private Button pveButton;
        private Button button3;
    }
}
