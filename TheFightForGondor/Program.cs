namespace TheFightForGondor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int waves = int.Parse(Console.ReadLine());
            List<int> plates = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
            List<int> orcs = new List<int>();

            for (int i = 1; i <= waves; i++)
            {
                orcs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    if (orcs[orcs.Count - 1] > plates[0])
                    {
                        orcs[orcs.Count - 1] -= plates[0];
                        plates.RemoveAt(0);

                        while (orcs[orcs.Count - 1] > 0 && plates.Count > 0)
                        {
                            if (orcs[orcs.Count - 1] > plates[0])
                            {
                                orcs[orcs.Count - 1] -= plates[0];
                                plates.RemoveAt(0);
                            }
                            else if (orcs[orcs.Count - 1] < plates[0])
                            {
                                plates[0] -= orcs[orcs.Count - 1];
                                orcs.RemoveAt(orcs.Count - 1);
                                break;
                            }
                            else
                            {
                                plates.RemoveAt(0);
                                orcs.RemoveAt(orcs.Count - 1);
                                break;
                            }
                        }
                    }
                    else if(orcs[orcs.Count - 1] < plates[0])
                    {
                        plates[0] -= orcs[orcs.Count - 1];
                        orcs.RemoveAt(orcs.Count - 1);
                    }
                    else
                    {
                        plates.RemoveAt(0);
                        orcs.RemoveAt(orcs.Count - 1);
                    }
                }
                if (plates.Count == 0)
                {
                    break;
                }
            }
            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: { string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs.OrderBy(o => o))}");
            }
        }
    }
}
