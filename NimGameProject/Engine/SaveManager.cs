using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NimGameProject.GameLogic
{
    internal class SaveManager
    {
        private const int MAX_SAVES = 6; //số file save tối đa được lưu trữ

        //tạo thư mục ngay chỗ file .exe để lưu trữ file save
        private string SAVE_FILE_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "history");

        public SaveManager()
        {

            if (!Directory.Exists(SAVE_FILE_PATH))
            {
                Directory.CreateDirectory(SAVE_FILE_PATH);
            }
        }

        //trả về để có gì nhớ cái đường dẫn file đã lưu 
        public string SaveGame(SaveData data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            string fileName = $"save_{DateTime.Now:yyyyMMdd_HHmmss}.json";
            string fullPath = Path.Combine(SAVE_FILE_PATH, fileName);

            File.WriteAllText(fullPath, json);

            LimitSavedGames();

            return fullPath;
        }

        public void LimitSavedGames()
        {
            if (Directory.Exists(SAVE_FILE_PATH))
            {
                string[] files = Directory
                    .GetFiles(SAVE_FILE_PATH, "save_*.json")
                    .OrderByDescending(f => File.GetCreationTime(f)) //sort từ mới tới cũ
                    .ToArray();
                if (files.Length > MAX_SAVES)
                {
                    for (int i = MAX_SAVES; i < files.Length; i++)
                    {
                        File.Delete(files[i]);
                    }
                }
            }
        }

        public string[] GetFilesPath()
        {
            if(Directory.Exists(SAVE_FILE_PATH))
            {
                string[] files = Directory
                    .GetFiles(SAVE_FILE_PATH, "save_*.json")
                    .OrderByDescending(f => File.GetCreationTime(f))
                    .ToArray();
                return files;
            }

            return null;
        }

    }
}
