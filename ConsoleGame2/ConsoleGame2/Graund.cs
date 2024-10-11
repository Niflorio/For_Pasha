using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame2
{
    public class Graund : Cell
    {
        public Graund(int x, int y, string value, bool movable, bool crossable) :
            base(x, y, value, movable, crossable)
        {
        }

        public Graund(int x, int y) :
            base(x, y, " ", false, true)
        {
        }
    }
}
