using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NimGameProject.GameLogic
{
    public class GameConfig
    {
        public int Rows { get; set; }
        public int MaxColumns { get; set; }
        
        public bool SoundOn { get; set; }

        public GameConfig()
        {
                Rows = 5;
                MaxColumns = 5;
                SoundOn = true;
        }

        public GameConfig(int rows, int maxColumns, bool soundOn)
        {
            Rows = rows;
            MaxColumns = maxColumns;
            SoundOn = soundOn;
        }
    }
}
