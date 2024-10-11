using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huita
{
    public class Program
    {
        public static void Main()
        {   

            for (int i = 0; i < 4;i++)
            {
                var game = new Game(i);
                game.Run();
            }
            Console.ReadKey();
        }

    }
}
