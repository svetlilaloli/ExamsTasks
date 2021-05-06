namespace Bombs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<int> effects = Array.ConvertAll(Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse).ToList();
            List<int> casings = Array.ConvertAll(Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse).ToList();

            Dictionary<string, int> bombTypes = new Dictionary<string, int>
            {
                { "Datura Bombs", 40 },
                { "Cherry Bombs", 60 },
                { "Smoke Decoy Bombs", 120 }
            };

            Dictionary<string, int> bombs = new Dictionary<string, int>
            {
                { "Datura Bombs", 0 },
                { "Cherry Bombs", 0 },
                { "Smoke Decoy Bombs", 0 }
            };

            bool pouchMade = false;

            while (effects.Count > 0 && casings.Count > 0)
            {
                bool bombCreated = false;
                int sum = effects[0] + casings[casings.Count - 1];

                foreach (var item in bombTypes)
                {
                    if (item.Value == sum)
                    {
                        bombs[item.Key]++;
                        effects.RemoveAt(0);
                        casings.RemoveAt(casings.Count - 1);
                        bombCreated = true;
                        break;
                    }                    
                }
                if (!bombCreated)
                {
                    casings[casings.Count - 1] -= 5;
                }

                if (IsFull(bombs))
                {
                    pouchMade = true;
                    break;
                }
            }

            PrintFirstLine(pouchMade);
            PrintLeftovers(effects, "Effects");
            PrintLeftovers(casings, "Casings");
            PrintBombs(bombs);
        }

        private static void PrintBombs(Dictionary<string, int> bombs)
        {
            foreach (var bomb in bombs.OrderBy(b => b.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }

        private static void PrintLeftovers(List<int> collection, string type)
        {
            if (collection.Count == 0)
            {
                Console.WriteLine($"Bomb {type}: empty");
            }
            else
            {
                Console.WriteLine($"Bomb {type}: {string.Join(", ", collection)}");
            }
        }

        private static void PrintFirstLine(bool pouchMade)
        {
            if (pouchMade)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
        }

        private static bool IsFull(Dictionary<string, int> bombs)
        {
            foreach (var bomb in bombs)
            {
                if (bomb.Value < 3)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
