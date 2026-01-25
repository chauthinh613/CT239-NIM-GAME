namespace TestGUIForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) 
        {
            MenuForm_Load();
        }

        private void MenuForm_Load()
        {
            MenuForm menu = new MenuForm();

            menu.Dock = DockStyle.Fill;
            menu.TopLevel = false;


            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(menu);

            menu.pveButtonClicked += GameForm_Load; //x? lý s? ki?n khi game ???c nh?n

            menu.Show();
        }
        private void GameForm_Load()
        {
            GameForm game = new GameForm();

            game.Dock = DockStyle.Fill;
            game.TopLevel = false;

            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(game);

            game.GameOver += MenuForm_Load;

            game.Show();
        }
    }
}
