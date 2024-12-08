using System;
using System.Linq;

namespace Game2048
{
    class Program
    {
        static int[,] board = new int[4, 4];
        static int score = 0;
        static Random rand = new Random();

        static void Main(string[] args)
        {
            InitializeGame();
            while (true)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("Score: " + score);
                Console.WriteLine("Use WASD to move tiles. Press 'Q' to quit.");

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Q)
                    break;

                bool moved = false;

                switch (key)
                {
                    case ConsoleKey.W:
                        moved = MoveUp();
                        break;
                    case ConsoleKey.S:
                        moved = MoveDown();
                        break;
                    case ConsoleKey.A:
                        moved = MoveLeft();
                        break;
                    case ConsoleKey.D:
                        moved = MoveRight();
                        break;
                }

                if (moved)
                {
                    AddTile();
                    if (IsGameOver())
                    {
                        Console.Clear();
                        DisplayBoard();
                        Console.WriteLine("Game Over! Final Score: " + score);
                        Console.WriteLine("Press Enter to exit.");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        {
                        }
                        break;
                    }
                }
            }
        }

        static void InitializeGame()
        {
            AddTile();
            AddTile();
        }

        static void DisplayBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    SetTileColor(board[i, j]);
                    Console.Write($"{board[i, j],4}");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static void SetTileColor(int value)
        {
            switch (value)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 16:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 32:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 64:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 128:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 256:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 512:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 1024:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 2048:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 4096:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 8192:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 16384:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 32768:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        static void AddTile()
        {
            int emptyCount = board.Cast<int>().Count(x => x == 0);
            if (emptyCount == 0) return;

            int pos = rand.Next(0, emptyCount);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == 0)
                    {
                        if (pos == 0)
                        {
                            board[i, j] = rand.Next(10) < 9 ? 2 : 4;
                            return;
                        }
                        pos--;
                    }
                }
            }
        }

        static bool MoveUp()
        {
            for (int col = 0; col < 4; col++)
            {
                int[] temp = new int[4];
                int index = 0;

                for (int row = 0; row < 4; row++)
                {
                    if (board[row, col] != 0)
                    {
                        temp[index++] = board[row, col];
                    }
                }

                for (int i = 0; i < index - 1; i++)
                {
                    if (temp[i] == temp[i + 1])
                    {
                        temp[i] *= 2;
                        score += temp[i];
                        temp[i + 1] = 0;
                    }
                }

                index = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (temp[i] != 0)
                    {
                        board[index++, col] = temp[i];
                    }
                }

                while (index < 4)
                {
                    board[index++, col] = 0;
                }
            }

            return true;
        }

        static bool MoveDown()
        {
            for (int col = 0; col < 4; col++)
            {
                int[] temp = new int[4];
                int index = 0;

                for (int row = 3; row >= 0; row--)
                {
                    if (board[row, col] != 0)
                    {
                        temp[index++] = board[row, col];
                    }
                }

                for (int i = 0; i < index - 1; i++)
                {
                    if (temp[i] == temp[i + 1])
                    {
                        temp[i] *= 2;
                        score += temp[i];
                        temp[i + 1] = 0;
                    }
                }

                index = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (temp[i] != 0)
                    {
                        board[3 - index++, col] = temp[i];
                    }
                }

                while (index < 4)
                {
                    board[3 - index++, col] = 0;
                }
            }

            return true;
        }

        static bool MoveLeft()
        {
            for (int row = 0; row < 4; row++)
            {
                int[] temp = new int[4];
                int index = 0;

                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] != 0)
                    {
                        temp[index++] = board[row, col];
                    }
                }

                for (int i = 0; i < index - 1; i++)
                {
                    if (temp[i] == temp[i + 1])
                    {
                        temp[i] *= 2;
                        score += temp[i];
                        temp[i + 1] = 0;
                    }
                }

                index = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (temp[i] != 0)
                    {
                        board[row, index++] = temp[i];
                    }
                }

                while (index < 4)
                {
                    board[row, index++] = 0;
                }
            }

            return true;
        }

        static bool MoveRight()
        {
            for (int row = 0; row < 4; row++)
            {
                int[] temp = new int[4];
                int index = 0;

                for (int col = 3; col >= 0; col--)
                {
                    if (board[row, col] != 0)
                    {
                        temp[index++] = board[row, col];
                    }
                }

                for (int i = 0; i < index - 1; i++)
                {
                    if (temp[i] == temp[i + 1])
                    {
                        temp[i] *= 2;
                        score += temp[i];
                        temp[i + 1] = 0;
                    }
                }

                index = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (temp[i] != 0)
                    {
                        board[row, 3 - index++] = temp[i];
                    }
                }

                while (index < 4)
                {
                    board[row, 3 - index++] = 0;
                }
            }

            return true;
        }

        static bool IsGameOver()
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (board[row, col] == 0)
                        return false;

                    if (col < 3 && board[row, col] == board[row, col + 1])
                        return false;

                    if (row < 3 && board[row, col] == board[row + 1, col])
                        return false;
                }
            }
            return true;
        }
    }
}