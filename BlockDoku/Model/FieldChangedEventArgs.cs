using System;
using System.Collections.Generic;
using System.Text;

namespace BlockDoku.Model
{
    public class FieldChangedEventArgs : EventArgs
    {
        public Color Color { get; private set; }
        public int X { get; private set; }

        public int Y { get; private set; }

        public FieldChangedEventArgs(int x, int y, Color color)
        {
            Color = color;
            X = x;
            Y = y;
        }
    }
}
