using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame2
{
    public class Player : Cell
    {
        public Player(int x, int y, string value, bool movable, bool crossable) :
            base(x, y, value, movable, crossable)
        {
        }

        public Player(int x, int y) :
            base(x, y, "C", false, true)
        {
        }
    }
}

