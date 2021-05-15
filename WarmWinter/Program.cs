using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    public class Program
    {
        public static void Main()
        {
            List<int> hats = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
            List<int> scarves = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarves.Count > 0)
            {
                if (hats[hats.Count - 1] > scarves[0])
                {
                    int sum = hats[hats.Count - 1] + scarves[0];
                    sets.Add(sum);
                    hats.RemoveAt(hats.Count - 1);
                    scarves.RemoveAt(0);
                }
                else if (hats[hats.Count - 1] < scarves[0])
                {
                    hats.RemoveAt(hats.Count - 1);
                }
                else
                {
                    scarves.RemoveAt(0);
                    hats[hats.Count - 1]++;
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max(p => p)}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
