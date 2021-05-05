using System;
using System.Linq;

namespace ReVolt
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            int i = -1, j = -1;
            bool playerWon = false;

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                if (matrix[row].Contains('f'))
                {
                    i = row;
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row][col] == 'f')
                        {
                            j = col;
                        }
                    }
                }
            }


            for (int c = 0; c < commandsCount; c++)
            {
                string command = Console.ReadLine();
                
                matrix[i][j] = '-';
                
                switch (command)
                {
                    case "up":
                        {
                            MoveBack(ref i, n);

                            if (matrix[i][j] == 'T')
                            {
                                MoveForward(ref i, n);
                            }
                            else if (matrix[i][j] == 'B')
                            {
                                MoveBack(ref i, n);
                            }
                        }
                        break;
                    case "down":
                        {
                            MoveForward(ref i, n);
                            if (matrix[i][j] == 'T')
                            {
                                MoveBack(ref i, n);
                            }
                            else if (matrix[i][j] == 'B')
                            {
                                MoveForward(ref i, n);
                            }
                        }
                        break;
                    case "left":
                        {
                            MoveBack(ref j, n);
                            if (matrix[i][j] == 'T')
                            {
                                MoveForward(ref j, n);
                            }
                            else if (matrix[i][j] == 'B')
                            {
                                MoveBack(ref j, n);
                            }
                        }
                        break;
                    case "right":
                        {
                            MoveForward(ref j, n);
                            if (matrix[i][j] == 'T')
                            {
                                MoveBack(ref j, n);
                            }
                            else if (matrix[i][j] == 'B')
                            {
                                MoveForward(ref j, n);
                            }
                        }
                        break;
                    default:
                        break;
                }

                if (matrix[i][j] == 'F')
                {
                    playerWon = true;
                    matrix[i][j] = 'f';
                    break;
                }
                
                matrix[i][j] = 'f';
            }

            if (playerWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
        private static void MoveBack(ref int i, int n)
        {
            if (i == 0)
            {
                i = n - 1;
            }
            else
            {
                i--;
            }
        }
        private static void MoveForward(ref int i, int n)
        {
            if (i == n - 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }
    }
}
