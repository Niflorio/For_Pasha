using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huita
{
    public class Plate : Cell
    {
        public Plate(int x, int y, string value, bool movable, bool crossable) :
            base(x, y, value, movable, crossable)
        {
        }

        public Plate(int x, int y) :
            base(x, y, "O", false, true)
        {
        }
    }
}
