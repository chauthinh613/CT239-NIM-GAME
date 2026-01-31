using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGameProject.GameLogic
{
    internal class Step
    {
        private int i, j; //vị trí chọn i = đống nào, j vị trí nào được ấn
        private bool currentPlayer;

        public Step(int i, int j, bool currentPlayer)
        {
            this.i = i;
            this.j = j;
            this.currentPlayer = currentPlayer;
        }

        public int I { get { return i; } }
        public int J { get { return j; } }
        public bool CurrentPlayer { get { return currentPlayer; } }
    }
}
