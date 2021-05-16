using System;
using System.Linq;

namespace SuperMario
{
    public class Program
    {
        public static void Main()
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] maze = new char[n][];
            bool isReached = false;
            int row = 0;
            int col = 0;

            for (int i = 0; i < n; i++)
            {
                maze[i] = Console.ReadLine().ToCharArray();
                if (maze[i].Contains('M'))
                {
                    row = i;
                    col = Array.IndexOf(maze[i], 'M');
                }
            }

            while (lives > 0 && !isReached)
            {
                char[] command = Console.ReadLine().Where(ch => ch != ' ').ToArray();
                int i = command[1] - '0';
                int j = command[2] - '0';

                maze[i][j] = 'B';
                lives--;

                switch (command[0])
                {
                    case 'W':
                        if (!IsOut(row - 1, n))
                        {
                            maze[row][col] = '-';
                            row--;
                            isReached = MakeAMove(maze, row, col, ref lives);
                        }
                        break;
                    case 'S':
                        if (!IsOut(row + 1, n))
                        {
                            maze[row][col] = '-';
                            row++;
                            isReached = MakeAMove(maze, row, col, ref lives);
                        }
                        break;
                    case 'A':
                        if (!IsOut(col - 1, maze[row].Length))
                        {
                            maze[row][col] = '-';
                            col--;
                            isReached = MakeAMove(maze, row, col, ref lives);
                        }
                        break;
                    case 'D':
                        if (!IsOut(col + 1, maze[row].Length))
                        {
                            maze[row][col] = '-';
                            col++;
                            isReached = MakeAMove(maze, row, col, ref lives);
                        }
                        break;
                    default:
                        break;
                }
            }
            if (isReached)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                maze[row][col] = 'X';
                Console.WriteLine($"Mario died at {row};{col}.");
            }
            PrintMaze(maze);
        }

        private static void PrintMaze(char[][] maze)
        {
            foreach (char[] row in maze)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool MakeAMove(char[][] maze, int row, int col, ref int lives)
        {
            if (maze[row][col] == 'B')
            {
                lives -= 2;
                maze[row][col] = 'M';
            }
            else if (maze[row][col] == 'P')
            {
                maze[row][col] = '-';
                return true;
            }
            else
            {
                maze[row][col] = 'M';
            }
            return false;
        }

        private static bool IsOut(int index, int size)
        {
            if (index < 0 || index >= size)
            {
                return true;
            }
            return false;
        }
    }
}
