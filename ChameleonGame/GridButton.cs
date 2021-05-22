using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows.Forms;

namespace ChameleonGame
{
    class GridButton : Button
    {
        private int _x;
        private int _y;
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public GridButton(int x, int y) { _x = x; _y = y; }
    }
}
