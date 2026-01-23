namespace TestGame
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
            pveButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // pveButton
            // 
            pveButton.Location = new Point(68, 161);
            pveButton.Name = "pveButton";
            pveButton.Size = new Size(155, 44);
            pveButton.TabIndex = 0;
            pveButton.Text = "Chơi với máy";
            pveButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 64);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // MenuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(pveButton);
            Name = "MenuControl";
            Size = new Size(300, 351);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button pveButton;
        private Label label1;
    }
}
