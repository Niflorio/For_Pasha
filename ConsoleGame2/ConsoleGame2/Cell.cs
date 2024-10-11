using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame2
{
    public class Cell
    {
        public int X;
        public int Y;
        public string Value;
        public bool IsCrossable;

        public Cell(int x, int y, string value, bool crossable)
        {
            X = x;
            Y = y;
            Value = value;
            IsCrossable = crossable;
        }
    }
}
