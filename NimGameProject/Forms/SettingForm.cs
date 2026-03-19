using NimGameProject.GameLogic;
using NimGameProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimGameProject.Forms
{
    public partial class SettingForm : Form
    {
        public event Action<GameConfig> ExitToMenu;

        GameConfig config;
        public SettingForm()
        {
            InitializeComponent();

            config = new GameConfig();

            DefaultShow();
        }

        public SettingForm(GameConfig gameConfig)
        {
            InitializeComponent();

            this.config = gameConfig;

            DefaultShow();
        }

        public void DefaultShow(){
            textPilesCount.Enabled = false;
            textPilesCount.Text = config.Rows.ToString();
            textPilesCount.TextAlign = ContentAlignment.MiddleCenter;
            textPilesCount.Padding = new Padding(5, 0, 0, 0);

            textColsCount.Enabled = false;
            textColsCount.Text = config.MaxColumns.ToString();
            textColsCount.TextAlign = ContentAlignment.MiddleCenter;
            textColsCount.Padding = new Padding(5, 0, 0, 0);


        }

        private void buttonMinusPiles_Click(object sender, EventArgs e)
        {
            config.Rows -= 1;
            if (config.Rows <= 1) 
            {
                config.Rows = 1;
                buttonMinusPiles.Enabled = false;
            }

            textPilesCount.Text = config.Rows.ToString();
            textPilesCount.TextAlign = ContentAlignment.MiddleCenter;

            buttonAddPiles.Enabled = true;

            UpdateAllButtons();
            
        }

        private void buttonAddPiles_Click(object sender, EventArgs e)
        {
            config.Rows += 1;
            if (config.Rows >= 10) 
            {
                config.Rows = 10;
                buttonAddPiles.Enabled = false;
            }

            textPilesCount.Text = config.Rows.ToString();

            buttonMinusPiles.Enabled = true;

            UpdateAllButtons();

        }

        private void buttonAddCols_Click(object sender, EventArgs e)
        {
            config.MaxColumns += 1;
            if (config.MaxColumns >= 10)
            {
                config.MaxColumns = 10;
                buttonAddCols.Enabled = false;
                buttonAddCols.BackgroundImage = Resources.button_plus_unable;
            }

            textColsCount.Text = config.MaxColumns.ToString();
            buttonMinusCols.Enabled = true;

            UpdateAllButtons();

        }

        private void buttonMinusCols_Click(object sender, EventArgs e)
        {
            config.MaxColumns -= 1;
            if(config.MaxColumns <= 1)
            {
                config.MaxColumns = 1;
                buttonMinusCols.Enabled = false;
            }

            textColsCount.Text = config.MaxColumns.ToString();
            buttonAddCols.Enabled = true;

            UpdateAllButtons();

        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            ExitToMenu.Invoke(config);
        }

        private void UpdateAllButtons()
        {
            UpdateButton(buttonMinusPiles, Effect.ButtonType.minus, buttonMinusPiles.Enabled);
            UpdateButton(buttonAddPiles, Effect.ButtonType.plus, buttonAddPiles.Enabled);
            UpdateButton(buttonMinusCols, Effect.ButtonType.minus, buttonMinusCols.Enabled);
            UpdateButton(buttonAddCols, Effect.ButtonType.plus, buttonAddCols.Enabled);

        }
        private void UpdateButton(Button btn, Effect.ButtonType type, bool enable)
        {
            string name = $"button_{type}";
            if(!enable)
            {
                name = $"button_{type}_unable";
            }
            
            var image = (Image)Resources.ResourceManager.GetObject(name);
            btn.BackgroundImage = image;
        }
        private void SettingForm_Load(object sender, EventArgs e)
        {
            LoadEffect();
        }

        private void LoadEffect()
        {
            Effect.ApplyButtonHoverEffect(buttonHome, Effect.ButtonType.home);
            Effect.ApplyButtonHoverEffect(buttonAddCols, Effect.ButtonType.plus);
            Effect.ApplyButtonHoverEffect(buttonMinusCols, Effect.ButtonType.minus);
            Effect.ApplyButtonHoverEffect(buttonAddPiles, Effect.ButtonType.plus);
            Effect.ApplyButtonHoverEffect(buttonMinusPiles, Effect.ButtonType.minus);
        }


    }
}
