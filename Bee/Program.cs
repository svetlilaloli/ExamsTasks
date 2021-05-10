namespace Bee
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] field = new char[n][];
            int row = 0;
            int col = 0;
            int pollinatedFlowers = 0;
            bool isLost = false;

            for (int i = 0; i < n; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();

                if (field[i].Contains('B'))
                {
                    row = i;
                    col = Array.IndexOf(field[i], 'B');
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                field[row][col] = '.';
                switch (command)
                {
                    case "up":
                        if (!MoveUp(field, ref row, col, ref pollinatedFlowers))
                        {
                            isLost = true;
                            break;
                        }
                        break;
                    case "down":
                        if (!MoveDown(field, ref row, col, ref pollinatedFlowers))
                        {
                            isLost = true;
                            break;
                        }
                        break;
                    case "left":
                        if (!MoveLeft(field, row, ref col, ref pollinatedFlowers))
                        {
                            isLost = true;
                            break;
                        }
                        break;
                    case "right":
                        if (!MoveRight(field, row, ref col, ref pollinatedFlowers))
                        {
                            isLost = true;
                            break;
                        }
                        break;
                    default:
                        break;
                }
                field[row][col] = 'B';
                if (isLost)
                {
                    field[row][col] = '.';
                    break;
                }
                command = Console.ReadLine();
            }

            if (isLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            PrintSuccessMessage(pollinatedFlowers, 5);
            PrintField(field);
        }
        private static void PrintSuccessMessage(int pollinatedFlowers, int minFlowers)
        {
            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {minFlowers - pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
        }

        private static void PrintField(char[][] field)
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
        private static bool MoveRight(char[][] field, int row, ref int col, ref int pollinatedFlowers)
        {
            if (!IsOut(col + 1, field.Length))
            {
                col++;
                if (field[row][col] == 'O')
                {
                    if (!IsOut(col + 1, field.Length))
                    {
                        field[row][col] = '.';
                        col++;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (field[row][col] == 'f')
                {
                    pollinatedFlowers++;
                }
                return true;
            }
            return false;
        }
        private static bool MoveLeft(char[][] field, int row, ref int col, ref int pollinatedFlowers)
        {
            if (!IsOut(col - 1, field.Length))
            {
                col--;
                if (field[row][col] == 'O')
                {
                    if (!IsOut(col - 1, field.Length))
                    {
                        field[row][col] = '.';
                        col--;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (field[row][col] == 'f')
                {
                    pollinatedFlowers++;
                }
                return true;
            }
            return false;
        }
        private static bool MoveDown(char[][] field, ref int row, int col, ref int pollinatedFlowers)
        {
            if (!IsOut(row + 1, field.Length))
            {
                row++;
                if (field[row][col] == 'O')
                {
                    if (!IsOut(row + 1, field.Length))
                    {
                        field[row][col] = '.';
                        row++;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (field[row][col] == 'f')
                {
                    pollinatedFlowers++;
                }
                return true;
            }
            return false;
        }
        private static bool MoveUp(char[][] field, ref int row, int col, ref int pollinatedFlowers)
        {
            if (!IsOut(row - 1, field.Length))
            {
                row--;
                if (field[row][col] == 'O')
                {
                    if (!IsOut(row - 1, field.Length))
                    {
                        field[row][col] = '.';
                        row--;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (field[row][col] == 'f')
                {
                    pollinatedFlowers++;
                }
                return true;
            }
            return false;
        }
        private static bool IsOut(int index, int n)
        {
            if (index < 0 || index >= n)
            {
                return true;
            }
            return false;
        }
    }
}
