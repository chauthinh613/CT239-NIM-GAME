namespace WinformGUITest
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            ShowMenu();
        }

        private void ShowMenu()
        {
            mainPanel.Controls.Clear();

            MenuControl menu = new MenuControl();

            menu.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(menu);

            menu.PvPButtonClicked += ShowGame;
        }

        private void ShowGame()
        {
            mainPanel.Controls.Clear();

            GameControl game = new GameControl();
            game.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(new GameControl());
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
