namespace FormGUIGame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //LoadMenu();
        }

        private void LoadMenu()
        {
            MenuForm menu = new MenuForm();

            menu.Dock = DockStyle.Fill;
            menu.TopLevel = false;

            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(menu);
            menu.Show();
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
