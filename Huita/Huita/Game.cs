using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huita
{
    public class Game 
    {
        // 0..9
        public int BorderLeftX = 0;
        public int BorderRightX = 9;
        // 0..9
        public int BorderTopY = 0;
        public int BorderBottomY = 9;

        List<Grass> grasses = new List<Grass>();
            
        List<Rock> rocks = new List<Rock>();
            
        List<Tree> treeses = new List<Tree>();
            
        Character player = new Character(5, 5);
            
        List<Plate> plates = new List<Plate>();

        List<Cell> cells = new List<Cell> ();

        public Game(int namber)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    grasses.Add(new Grass(x, y));
                }
            }

            switch (namber)
            {
                case 0:
                    rocks.Add(new Rock(5, 4));
                    rocks.Add(new Rock(5, 6));
                    treeses.Add(new Tree(7, 7));
                    plates.Add(new Plate(2, 2));
                    plates.Add(new Plate(2, 3));
                    break;
                case 1:
                    rocks.Add(new Rock(5, 4));
                    rocks.Add(new Rock(5, 6));
                    treeses.Add(new Tree(7, 9));
                    treeses.Add(new Tree(8, 6));
                    treeses.Add(new Tree(3, 1));
                    treeses.Add(new Tree(4, 5));
                    plates.Add(new Plate(2, 2));
                    plates.Add(new Plate(2, 3));
                    plates.Add(new Plate(2, 5));
                    break;
                case 2:
                    rocks.Add(new Rock(5, 4));
                    rocks.Add(new Rock(6, 4));
                    rocks.Add(new Rock(5, 6));
                    treeses.Add(new Tree(7, 9));
                    treeses.Add(new Tree(8, 6));
                    treeses.Add(new Tree(3, 1));
                    treeses.Add(new Tree(4, 5));
                    plates.Add(new Plate(2, 2));
                    plates.Add(new Plate(2, 3));
                    plates.Add(new Plate(2, 5));
                    break;
                case 3:
                    rocks.Add(new Rock(5, 4));
                    rocks.Add(new Rock(6, 4));
                    rocks.Add(new Rock(5, 6));
                    treeses.Add(new Tree(7, 9));
                    treeses.Add(new Tree(8, 6));
                    treeses.Add(new Tree(3, 1));
                    treeses.Add(new Tree(4, 5));
                    treeses.Add(new Tree(2, 9));
                    treeses.Add(new Tree(8, 3));
                    treeses.Add(new Tree(3, 4));
                    treeses.Add(new Tree(1, 5));
                    plates.Add(new Plate(2, 2));
                    plates.Add(new Plate(2, 3));
                    plates.Add(new Plate(2, 5));
                    break;

            }
            cells.AddRange(grasses);
            cells.AddRange(rocks);
            cells.AddRange(treeses);
            cells.Add(player);
            cells.AddRange(plates);
        }

        
        public void Print()
        {
            var field = new string[10, 10];

            foreach (var grass in grasses)
            {
                field[grass.X, grass.Y] = grass.Value;
            }

            foreach (var rock in rocks)
            {
                field[rock.X, rock.Y] = rock.Value;
            }

            foreach (var tree in treeses)
            {
                field[tree.X, tree.Y] = tree.Value;
            }

            field[player.X, player.Y] = player.Value;

            foreach (var plate in plates)
            {
                field[plate.X, plate.Y] = plate.Value;

                if (player.X == plate.X && player.Y == plate.Y)
                {
                    field[plate.X, plate.Y] = "Э";
                }

                foreach (var rock in rocks)
                {
                    if (rock.X == plate.X && rock.Y == plate.Y)
                    {
                        field[plate.X, plate.Y] = "Я";
                    }
                }
            }

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (field[y, x] == "T")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (field[y, x] == "R")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    if (field[y, x] == "C")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (field[y, x] == "#")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    Console.Write(field[y, x] + " ");
                }
                Console.WriteLine();
            }

        }
        public bool CanIMoveCharacter(int x, int y)
        {
            int targetX = player.X + x;
            int targetY = player.Y + y;

            bool flag = true;
            if (targetX < 0 || targetX > 9 || targetY < 0 || targetY > 9)
            {
                return false;
            }
            foreach (var cell in cells)
            {
                if (cell.X == targetX && cell.Y == targetY)
                {
                    if (!cell.IsMovable && !cell.IsCrossable)
                    {
                        flag = false;
                    }
                }
            }

            return flag;
        }
        public int IndexRock(int x, int y)
        {
            int targetX = player.X + x;
            int targetY = player.Y + y;
            int index = 0;

            foreach (var rock in rocks)
            {
                if (targetX == rock.X && targetY == rock.Y)
                {
                    break;
                }
                index++;
            } 
            if (index > rocks.Count - 1)
            {
                return 0;
            }
            return index;
        }
        public bool Push(int x, int y, int index)
        {
            int targetX = player.X + x;
            int targetY = player.Y + y;
            bool flag = false;
                if (targetX == rocks[index].X && targetY == rocks[index].Y)
                {
                    flag = true;
                }
            return flag;
        }
        public bool CanIMoveRock(int x, int y, int index)
        {
            int targetX = player.X + x;
            int targetY = player.Y + y;
            bool flag = true;

            if (targetX + x < 0 || targetX + x > 9 || targetY + y < 0 || targetY + y > 9)
            {
                return false;
            }

            if (targetX == rocks[index].X && targetY == rocks[index].Y)
            {
                foreach (var cell in cells)
                {
                    if (x == 1)
                    {
                        if ((targetX + 1 == cell.X && targetY == cell.Y))
                        {
                            if (!cell.IsCrossable)
                            {
                                flag = false; break;
                            }
                        }
                    }
                    if (x == -1)
                    {
                        if ((targetX - 1 == cell.X && targetY == cell.Y))
                        {
                            if (!cell.IsCrossable)
                            {
                                flag = false; break;
                            }
                        }
                    }
                    if (y == 1)
                    {
                        if ((targetX == cell.X && targetY + 1 == cell.Y))
                        {
                            if (!cell.IsCrossable)
                            {
                                flag = false; break;
                            }
                        }
                    }
                    if (y == -1)
                    {
                        if ((targetX == cell.X && targetY - 1 == cell.Y))
                        {
                            if (!cell.IsCrossable)
                            {
                                flag = false; break;
                            }
                        }
                    }
                }
            }
            else 
            {
                 flag = false;   
            }
            return flag;
        }

        public void MoveCharacter(int x, int y)
        {
            player.X += x;
            player.Y += y;
        }

        public void MoveRock(int x, int y, int index)
        {
            rocks[index].X += x;
            rocks[index].Y += y;
        }


        public void Run()
        {

            int KeyX = -1;
            int KeyY = 0;
            int KeyI = 0;
            bool KeyC = true;
            bool KeyB = true;

            while (true)
            {
                Print();    
                var key = Console.ReadKey();
                Console.Clear();

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        KeyX = -1;
                        KeyY = 0;
                        KeyI = IndexRock(KeyX, KeyY);
                        KeyC = CanIMoveRock(KeyX, KeyY, KeyI);
                        KeyB = Push(KeyX, KeyY, KeyI);
                        if (KeyC && KeyB)
                        {
                            MoveRock(KeyX, KeyY, KeyI);
                            MoveCharacter(KeyX, KeyY);
                        }
                        if (!KeyC && !KeyB)
                        {
                            if (CanIMoveCharacter(KeyX, KeyY))
                            {
                                MoveCharacter(KeyX, KeyY);
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        KeyX = 1;
                        KeyY = 0;
                        KeyI = IndexRock(KeyX, KeyY);
                        KeyC = CanIMoveRock(KeyX, KeyY, KeyI);
                        KeyB = Push(KeyX, KeyY, KeyI);
                        if (KeyC && KeyB)
                        {
                            MoveRock(KeyX, KeyY, KeyI);
                            MoveCharacter(KeyX, KeyY);
                        }
                        if (!KeyC && !KeyB)
                        {
                            if (CanIMoveCharacter(KeyX, KeyY))
                            {
                                MoveCharacter(KeyX, KeyY);
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        KeyX = 0;
                        KeyY = 1;
                        KeyI = IndexRock(KeyX, KeyY);
                        KeyC = CanIMoveRock(KeyX, KeyY, KeyI);
                        KeyB = Push(KeyX, KeyY, KeyI);
                        if (KeyC && KeyB)
                        {
                            MoveRock(KeyX, KeyY, KeyI);
                            MoveCharacter(KeyX, KeyY);
                        }
                        if (!KeyC && !KeyB)
                        {
                            if (CanIMoveCharacter(KeyX, KeyY))
                            {
                                MoveCharacter(KeyX, KeyY);
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        KeyX = 0;
                        KeyY = -1;
                        KeyI = IndexRock(KeyX, KeyY);
                        KeyC = CanIMoveRock(KeyX, KeyY, KeyI);
                        KeyB = Push(KeyX, KeyY, KeyI);
                        if (KeyC && KeyB)
                        {
                            MoveRock(KeyX, KeyY, KeyI);
                            MoveCharacter(KeyX, KeyY);
                        }
                        if (!KeyC && !KeyB)
                        {
                            if (CanIMoveCharacter(KeyX, KeyY))
                            {
                                MoveCharacter(KeyX, KeyY);
                            }
                        }
                        break;
                }
                bool flag1 = false;
                foreach (var plate in plates)
                {
                    flag1 = false;
                    foreach (var rock in rocks)
                    {
                        if (plate.X == rock.X && plate.Y == rock.Y)
                        {
                            flag1 = true; break;
                        }
                        if (plate.X == player.X && plate.Y == player.Y)
                        {
                            flag1 = true; break;
                        }

                    }

                    if (!flag1)
                    {
                        break;
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
