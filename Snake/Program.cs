namespace Snake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            int row = 0;
            int col = 0;
            int food = 0;
            List<int> burrows = new List<int>();

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
                if (matrix[i].Contains('S'))
                {
                    row = i;
                    col = Array.IndexOf(matrix[i], 'S');
                }
                if (matrix[i].Contains('B'))
                {
                    burrows.Add(i);
                    burrows.Add(Array.IndexOf(matrix[i], 'B'));
                }
            }

            while (food < 10)
            {
                string command = Console.ReadLine();
                matrix[row][col] = '.';

                if (!Update(command, ref row, ref col, n))
                {
                    break;
                }
                MakeTheMove(matrix, burrows, ref row, ref col, ref food);
                matrix[row][col] = 'S';
            }
            if (food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }
            Console.WriteLine($"Food eaten: {food}");
            foreach (var currentRow in matrix)
            {
                Console.WriteLine(string.Join("", currentRow));
            }
        }

        private static bool Update(string command, ref int row, ref int col, int n)
        {
            if (command == "up")
            {
                if (InRange(row - 1, n))
                {
                    row--;
                }
                else
                {
                    return false;
                }
            }
            else if (command == "down")
            {
                if (InRange(row + 1, n))
                {
                    row++;
                }
                else
                {
                    return false;
                }
            }
            else if (command == "left")
            {
                if (InRange(col - 1, n))
                {
                    col--;
                }
                else
                {
                    return false;
                }
            }
            else if (command == "right")
            {
                if (InRange(col + 1, n))
                {
                    col++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static bool InRange(int index, int n)
        {
            if (index >= 0 && index <= n - 1)
            {
                return true;
            }
            return false;
        }

        private static void MakeTheMove(char[][] matrix, List<int> burrows, ref int row, ref int col, ref int food)
        {
            if (matrix[row][col] == '*')
            {
                food++;
            }
            else if (matrix[row][col] == 'B')
            {
                matrix[row][col] = '.';
                if (burrows[0] == row && burrows[1] == col)
                {
                    row = burrows[2];
                    col = burrows[3];
                }
                else if (burrows[2] == row && burrows[3] == col)
                {
                    row = burrows[0];
                    col = burrows[1];
                }
            }
        }
    }
}
