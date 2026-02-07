using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGameProject.GameLogic
{
    internal class Step
    {
        private int row, col; //vị trí chọn i = đống nào, j vị trí nào được ấn
        private bool currentPlayer;

        public Step(int i, int j, bool currentPlayer)
        {
            this.row = i;
            this.col = j;
            this.currentPlayer = currentPlayer;
        }

        public int Row { get { return row; } }
        public int Col { get { return col; } }
        public bool CurrentPlayer { get { return currentPlayer; } }
    }
}
