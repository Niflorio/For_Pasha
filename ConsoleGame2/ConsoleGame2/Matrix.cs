using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame2
{
    public class Matrix
    {
        private string Shuffle(string text)
        {
            var rnd = new Random();
            var result = text.ToCharArray()
                            .OrderBy(c => rnd.Next())
                            .ToArray();
            return new string(result);
        }
        public string RemoveEnd(string str, int len)
        {
            if (str.Length < len)
            {
                return string.Empty;
            }

            return str.Remove(str.Length - len);
        }
        public void Mazayka(int HeightIn, int WidhtIn)
        {
            int height = HeightIn + 1;
            int widht = WidhtIn + 1;
            int pX = 1;
            int pY = 1;
            bool[,] mazayka = new bool[widht, height];

            for (int i = 0; i < widht; i++) {
                for (int j = 0; j < height; j++) {
                    mazayka[i, j] = ((i % 2 != 0 && j % 2 != 0)
                                    && (i > 0 && j > 0)
                                    && (i < widht - 1 && j < height - 1));
                }
            }
            string history = "";
            string AWDS = "AWDS";
            int X = 0;
            int Y = 0;
            bool flag = true;
            do
            {

                foreach (char target in Shuffle(AWDS))
                {
                    X = 0;
                    Y = 0;
                    switch (target)
                    {
                        case 'A':
                            X = -2;
                            break;
                        case 'W':
                            Y = -2;
                            break;
                        case 'D':
                            X = 2;
                            break;
                        case 'S':
                            Y = 2;
                            break;
                    }
                    if (pX + X > 0 && pX + X < widht)
                    {
                        if (pY + Y > 0 && pY + Y < height)
                        {
                            if (mazayka[pX + X, pY + Y])
                            {
                                mazayka[pX, pY] = false;
                                mazayka[pX + X, pY + Y] = false;
                                mazayka[pX + X / 2, pY + Y / 2] = true;
                                pX += X;
                                pY += Y;
                                history += target;
                                flag = true;
                                break;
                            }
                        }
                    }
                    flag = false;
                }
                if (!flag && history.Length > 0)
                {
                    switch (history[history.Length - 1])
                    {
                        case 'A':
                            X = 2;
                            Y = 0;
                            break;
                        case 'W':
                            Y = 2;
                            X = 0;
                            break;
                        case 'D':
                            X = -2;
                            Y = 0;
                            break;
                        case 'S':
                            Y = -2;
                            X = 0;
                            break;
                    }
                    pX += X; pY += Y;
                    history = RemoveEnd(history,1);
                }
                for (int j = 0; j < height ; j++)
                {
                    for (int i = 0; i < widht; i++)
                    {
                        if (i % 2 == 1 && j % 2 == 1)
                        {
                            Console.Write("# ");
                            continue;
                        }

                        if (mazayka[i, j])
                        {
                            Console.Write("# ");
                        }
                        else
                        {
                            Console.Write("$ ");
                        }

                    }
                    Console.WriteLine("");
                }
                Console.WriteLine(history);
            }
            while (!(pX == 1 && pY == 1));
            Console.WriteLine("Ебать");
        }
            
    }
}
