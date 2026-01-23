

namespace TestGame
{
    public partial class mainForm : Form
    {
        int itemWidth = 50;
        int itemHeigh = 50;



        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); //xoá hết tất cả trong panel

            int n = (int)numericUpDown1.Value; //phải ép kiểu
            GameLogic gameLogic = new GameLogic(n);



            for (int i = 1; i <= gameLogic.n; i++)
            {
                Button btn = new Button();
                //btn.Text = i.ToString();
                btn.Width = itemWidth;
                btn.Height = itemHeigh;
                btn.Top = 10;
                btn.Left = 10 + (itemWidth + 5) * i;
                //btn.BackColor = Color.Transparent;
                btn.FlatStyle = FlatStyle.Flat;
                //btn.FlatAppearance.BorderSize = 0;
                btn.BackgroundImage = Image.FromFile(@"D:/Download/pixil-frame-0 (1).png");
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.FlatAppearance.BorderSize = 0;

                btn.TabStop = false;

                btn.Click += Btn_Click;

                panel1.Controls.Add(btn);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            clickedBtn.Visible = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //this.MaximumSize = new Size(600, 800);
            panelMain.Controls.Add(new MenuControl());
        }
        private void LoadScreen(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        public void MenuControl()
        {
            
        }

        public void PlayControl()
        {
            panelMain.Controls.Clear(); //xoá hết tất cả trong panel

            int n = (int)numericUpDown1.Value; //phải ép kiểu
            GameLogic gameLogic = new GameLogic(n);



            for (int i = 1; i <= gameLogic.n; i++)
            {
                Button btn = new Button();
                //btn.Text = i.ToString();
                btn.Width = itemWidth;
                btn.Height = itemHeigh;
                btn.Top = 10;
                btn.Left = 10 + (itemWidth + 5) * i;
                //btn.BackColor = Color.Transparent;
                btn.FlatStyle = FlatStyle.Flat;
                //btn.FlatAppearance.BorderSize = 0;
                btn.BackgroundImage = Image.FromFile(@"D:/Download/pixil-frame-0 (1).png");
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.FlatAppearance.BorderSize = 0;

                btn.TabStop = false;

                btn.Click += Btn_Click;

                panel1.Controls.Add(btn);
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
