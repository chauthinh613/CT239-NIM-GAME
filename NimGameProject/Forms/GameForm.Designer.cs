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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPlayer1 = new System.Windows.Forms.Button();
            this.buttonPlayer2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelBoard, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.68421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 663);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(594, 113);
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
            this.buttonPlayer1.Size = new System.Drawing.Size(114, 107);
            this.buttonPlayer1.TabIndex = 0;
            this.buttonPlayer1.UseVisualStyleBackColor = true;
            this.buttonPlayer1.Click += new System.EventHandler(this.buttonPlayer1_Click);
            // 
            // buttonPlayer2
            // 
            this.buttonPlayer2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPlayer2.BackgroundImage")));
            this.buttonPlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPlayer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlayer2.FlatAppearance.BorderSize = 0;
            this.buttonPlayer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayer2.Location = new System.Drawing.Point(310, 3);
            this.buttonPlayer2.Name = "buttonPlayer2";
            this.buttonPlayer2.Size = new System.Drawing.Size(114, 107);
            this.buttonPlayer2.TabIndex = 1;
            this.buttonPlayer2.UseVisualStyleBackColor = true;
            this.buttonPlayer2.Click += new System.EventHandler(this.buttonPlayer2_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 9;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.buttonHome, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonReset, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonHelp, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonUndo, 7, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(594, 74);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // buttonHome
            // 
            this.buttonHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHome.BackgroundImage")));
            this.buttonHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Location = new System.Drawing.Point(133, 3);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(66, 68);
            this.buttonHome.TabIndex = 0;
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonReset.BackgroundImage")));
            this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Location = new System.Drawing.Point(220, 3);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(66, 68);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHelp.BackgroundImage")));
            this.buttonHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHelp.FlatAppearance.BorderSize = 0;
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHelp.Location = new System.Drawing.Point(307, 3);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(66, 68);
            this.buttonHelp.TabIndex = 2;
            this.buttonHelp.UseVisualStyleBackColor = true;
            // 
            // buttonUndo
            // 
            this.buttonUndo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUndo.BackgroundImage")));
            this.buttonUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUndo.FlatAppearance.BorderSize = 0;
            this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUndo.Location = new System.Drawing.Point(394, 3);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(66, 68);
            this.buttonUndo.TabIndex = 3;
            this.buttonUndo.UseVisualStyleBackColor = true;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(600, 800);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonPlayer1;
        private System.Windows.Forms.Button buttonPlayer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonUndo;
    }
}