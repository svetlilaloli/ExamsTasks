using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    public class Program
    {
        public static void Main()
        {
            List<int> lilies = Array.ConvertAll(Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse).ToList();
            List<int> roses = Array.ConvertAll(Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse).ToList();
            int wreaths = 0;
            int leftovers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int sum = lilies.Last() + roses[0];
                if (sum == 15)
                {
                    wreaths++;
                    lilies.RemoveAt(lilies.Count - 1);
                    roses.RemoveAt(0);
                }
                else if (sum > 15)
                {
                    lilies[lilies.Count - 1] -= 2;
                }
                else
                {
                    leftovers += sum;
                    lilies.RemoveAt(lilies.Count - 1);
                    roses.RemoveAt(0);
                }

                if (wreaths >= 5)
                {
                    break;
                }
            }

            wreaths += leftovers / 15;

            Print(wreaths);
        }
        private static void Print(int wreaths)
        {
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
