using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame2
{
    public class Game
    {
        static Random random = new Random();

        static public int BorderX = random.Next(3,15) * 2;
        static public int BorderY = random.Next(3,15) * 2;

        static Matrix matrix = new Matrix();

        bool[,] Maze = matrix.Mazayka(BorderX, BorderY); 

        List<Graund> graunds = new List<Graund>();

        List<Wall> walls = new List<Wall>();

        Player player = new Player(0, 1);

        List<Gate> gates = new List<Gate>();

        List<Cell> cells = new List<Cell>();



        public Game()
        {


            for (int x = 0; x < BorderX +1; x++)
            {
                for (int y = 0; y < BorderY +1; y++)
                {
                    if (Maze[x, y])
                    {
                        graunds.Add(new Graund(x, y));
                    }
                    else
                    {
                        walls.Add(new Wall(x, y));
                    }
                }
            }
            gates.Add(new Gate(BorderX, BorderY - 1));

                        cells.AddRange(graunds);
            cells.AddRange(walls);
            cells.Add(player);
            cells.AddRange(gates);

        }

        public void Print()
        {
            var field = new string[BorderX + 1, BorderY + 1];

            foreach (var graund in graunds)
            {
                field[graund.X, graund.Y] = graund.Value;
            }

            foreach (var wall in walls)
            {
                field[wall.X, wall.Y] = wall.Value;
            }

            field[player.X, player.Y] = player.Value;

            foreach (var gate in gates)
            {
                field[gate.X, gate.Y] = gate.Value;

                if (player.X == gate.X && player.Y == gate.Y)
                {
                    field[gate.X, gate.Y] = "Э";
                }
            }

            for (int y = 0; y < BorderY + 1; y++)
            {
                for (int x = 0; x < BorderX + 1; x++)
                {
                    if (field[x, y] == "#")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    if (field[x, y] == "C")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(field[x, y] + " ");
                }
                Console.WriteLine();
            }

        }
        public bool CanIMoveCharacter(int x, int y)
        {
            int targetX = player.X + x;
            int targetY = player.Y + y;

            bool flag = true;
            if (targetX < 0 || targetX > BorderX || targetY < 0 || targetY > BorderY)
            {
                return false;
            }
            foreach (var cell in cells)
            {
                if (cell.X == targetX && cell.Y == targetY)
                {
                    if (!cell.IsCrossable)
                    {
                        flag = false;
                    }
                }
            }
            return flag;
        }
        public void MoveCharacter(int x, int y)
        {
            player.X += x;
            player.Y += y;
        }


        public void Run()
        {

            while (true)
            {
                Print();
                var key = Console.ReadKey();

                Console.Clear();

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (CanIMoveCharacter(-1, 0))
                        {
                            MoveCharacter(-1, 0);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (CanIMoveCharacter(1, 0))
                        {
                            MoveCharacter(1, 0);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (CanIMoveCharacter(0, 1))
                        {
                            MoveCharacter(0, 1);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (CanIMoveCharacter(0, -1))
                        {
                            MoveCharacter(0, -1);
                        }
                        break;
                }
                bool flag1 = false;
                foreach (var gate in gates)
                {

                    if (gate.X == player.X && gate.Y == player.Y)
                    {
                        flag1 = true; break;
                    }
             
                }
                if (flag1)
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("Победа");
            Console.ReadKey();
            Console.Clear();


        }


    }



}

