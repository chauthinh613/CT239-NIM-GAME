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
            menu.Anchor = AnchorStyles.None;
            mainPanel.Controls.Add(menu);

            menu.PvPButtonClicked += ShowGame;
        }

        private void ShowGame()
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(new GameControl());
        }

    }
}
