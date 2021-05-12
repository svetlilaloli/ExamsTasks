using System;
using System.Collections.Generic;
using System.Linq;

namespace Selling
{
    public class Program
    {
        private static readonly List<int[]> pillars = new List<int[]>(2);
        private static int money = 0;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] bakery = new char[n][];
            int row = 0;
            int col = 0;
            string command = Console.ReadLine();
            bool isOut = false;

            for (int i = 0; i < n; i++)
            {
                bakery[i] = Console.ReadLine().ToCharArray();
                if (bakery[i].Contains('S'))
                {
                    row = i;
                    col = Array.IndexOf(bakery[i], 'S');
                }
                if (bakery[i].Contains('O'))
                {
                    pillars.Add(new int[] { i, Array.IndexOf(bakery[i], 'O') });
                }
            }

            while (money < 50)
            {
                bakery[row][col] = '-';
                switch (command)
                {
                    case "up":
                        {
                            if (!IsOut(row - 1, bakery.Length))
                            {
                                row--;
                            }
                            else
                            {
                                isOut = true;
                            }
                        }
                        break;
                    case "down":
                        {
                            if (!IsOut(row + 1, n))
                            {
                                row++;
                            }
                            else
                            {
                                isOut = true;
                            }
                        }
                        break;
                    case "left":
                        {
                            if (!IsOut(col - 1, bakery.Length))
                            {
                                col--;
                            }
                            else
                            {
                                isOut = true;
                            }
                        }
                        break;
                    case "right":
                        {
                            if (!IsOut(col + 1, n))
                            {
                                col++;
                            }
                            else
                            {
                                isOut = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
                NextMove(bakery, ref row, ref col);
                if (money >= 50)
                {
                    break;
                }
                if (isOut)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (isOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {money}");
            PrintBakery(bakery);
        }

        private static void PrintBakery(char[][] bakery)
        {
            foreach (var item in bakery)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static void NextMove(char[][] bakery, ref int row, ref int col)
        {
            if (bakery[row][col] == 'O')
            {
                bakery[row][col] = '-';
                var pillar = OtherPillar(pillars, row, col);
                row = pillar[0];
                col = pillar[1];
                bakery[row][col] = 'S';
            }
            else if (char.IsDigit(bakery[row][col]))
            {
                money += bakery[row][col] - '0';
                bakery[row][col] = 'S';
            }
        }

        private static int[] OtherPillar(List<int[]> pillars, int row, int col)
        {
            if (pillars[0][0] == row && pillars[0][1] == col)
            {
                return new int[] { pillars[1][0], pillars[1][1] };
            }
            else
            {
                return new int[] { pillars[0][0], pillars[0][1] };
            }
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
