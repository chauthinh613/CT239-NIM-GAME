using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGameProject.GameLogic
{
    public class SaveData
    {
        public bool CurrentPlayer { get; set; }
        public bool IsGameOver { get; set; }
        public bool IsPVP { get; set; }
        public int[][] Board { get; set; }

    }
}
