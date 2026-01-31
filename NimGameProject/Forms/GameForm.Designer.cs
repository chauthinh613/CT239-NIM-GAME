namespace NimGameProject.Forms
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPlayer1 = new System.Windows.Forms.Button();
            this.buttonPlayer2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Orchid;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelBoard, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 800);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelBoard
            // 
            this.panelBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelBoard.Location = new System.Drawing.Point(200, 330);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(200, 100);
            this.panelBoard.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonPlayer1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonPlayer2, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 656);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(594, 103);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonPlayer1
            // 
            this.buttonPlayer1.BackgroundImage = global::NimGameProject.Properties.Resources.dog;
            this.buttonPlayer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlayer1.FlatAppearance.BorderSize = 0;
            this.buttonPlayer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayer1.Location = new System.Drawing.Point(170, 3);
            this.buttonPlayer1.Name = "buttonPlayer1";
            this.buttonPlayer1.Size = new System.Drawing.Size(114, 97);
            this.buttonPlayer1.TabIndex = 0;
            this.buttonPlayer1.Text = "1";
            this.buttonPlayer1.UseVisualStyleBackColor = true;
            this.buttonPlayer1.Click += new System.EventHandler(this.buttonPlayer1_Click);
            // 
            // buttonPlayer2
            // 
            this.buttonPlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPlayer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlayer2.FlatAppearance.BorderSize = 0;
            this.buttonPlayer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayer2.Location = new System.Drawing.Point(310, 3);
            this.buttonPlayer2.Name = "buttonPlayer2";
            this.buttonPlayer2.Size = new System.Drawing.Size(114, 97);
            this.buttonPlayer2.TabIndex = 1;
            this.buttonPlayer2.Text = "2";
            this.buttonPlayer2.UseVisualStyleBackColor = true;
            this.buttonPlayer2.Click += new System.EventHandler(this.buttonPlayer2_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(600, 800);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(600, 800);
            this.MinimumSize = new System.Drawing.Size(600, 800);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonPlayer1;
        private System.Windows.Forms.Button buttonPlayer2;
    }
}