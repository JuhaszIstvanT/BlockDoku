using System;
using System.Collections.Generic;
using System.Text;

namespace BlockDoku.Model
{
    public class DisplayChangedEventArgs : EventArgs
    {
        public Color[,] Display { get; private set; }

        public DisplayChangedEventArgs(Color[,] display)
        {
            Display = display;
        }
    }
}
