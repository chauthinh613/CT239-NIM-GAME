using NimGameProject.GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimGameProject.Forms
{
    public partial class HistoryForm : Form
    {
        public event Action<(SaveData saveData, string fullPath)> LoadSavedGame;
        public event Action ExitToMenu;

        SaveManager manager = new SaveManager();
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            string[] files = manager.GetFilesPath();

            if (files == null) return;

            foreach (string file in files) 
            {
                try
                {
                    //lấy dữ liệu để hiển thị chế độ là gì
                    string json = File.ReadAllText(file);
                    SaveData data = JsonSerializer.Deserialize<SaveData>(json);

                    if (data.Board == null
                            || data.Board.Length == 0
                            || data.Board.All(row => row.Length == 0)
                            || data.IsGameOver == true)
                    {
                        //File.Delete(file); // xóa file nếu nó không hợp lệ
                        continue; // bỏ qua file nếu nó không hợp lệ
                    }

                    Button button = createHistoryButton(file, data.IsPVP);

                    flowPanelHistory.Controls.Add(button);
                }
                catch (Exception)
                {
                    continue; // nếu có file nào lỗi định dạng thì kệ 
                }
            }

            //thêm hiệu ứng cho home
            EffectManager.ApplyButtonHoverEffect(buttonHome, EffectManager.ButtonType.home);
        }

        private Button createHistoryButton(string path, bool isPvP)
        {
            Button button = new Button();

            button.Text = formatName(path, isPvP);
            button.Width = flowPanelHistory.ClientSize.Width - 10;
            button.Height = flowPanelHistory.ClientSize.Width/5;


            //chỉnh thiết kế
            button.BackgroundImage = Properties.Resources.textbox_background;
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            button.Tag = path;

            button.Click += HistoryButton_Click;

            EffectManager.ApplyTextboxHoverEffect(button);

            return button;
        }

        private String formatName(string path, bool isPvP)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);

            //bỏ chữ "save_" ở đầu tên file
            string timePart = fileName.Replace("save_", "");

            DateTime date = DateTime.ParseExact(timePart, "yyyyMMdd_HHmmss", null);

            string text;
            if (isPvP)
            {
                text = "PVP ";
            }
            else
            {
                text = "PVE ";
            }

            text += date.ToString("dd/MM/yyyy HH:mm:ss");

            return text;
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            //lấy lại đường dẫn của cái file đã lưu trong thuộc tính Tag của button
            string fullPath = button.Tag as string;

            string json = File.ReadAllText(fullPath);
            SaveData data = JsonSerializer.Deserialize<SaveData>(json);

            LoadSavedGame.Invoke((data, fullPath));
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            ExitToMenu.Invoke();
        }
    }
}
