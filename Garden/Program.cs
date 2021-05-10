using System;

namespace Garden
{
    public class Program
    {
        public static void Main()
        {
            int[] size = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[,] garden = new int[size[0], size[1]];

            string command = Console.ReadLine();
            
            while (command != "Bloom Bloom Plow")
            {
                int[] position = Array.ConvertAll(command.Split(), int.Parse);
                int row = position[0];
                int col = position[1];

                try
                {
                    for (int i = 0; i < size[0]; i++)
                    {
                        garden[row, i]++;
                        garden[i, col]++;
                    }

                    garden[row, col]--;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid coordinates.");
                }                
                
                command = Console.ReadLine();
            }

            PrintGarden(garden, size[0]);
        }

        private static void PrintGarden(int[,] garden, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
