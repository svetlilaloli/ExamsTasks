using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    public class Program
    {
        public static void Main()
        {
            var firstLootBox = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
            var secondLootBox = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
            List<int> claimedItems = new List<int>();

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int first = firstLootBox[0];
                int second = secondLootBox[secondLootBox.Count - 1];
                int sum = first + second;
                
                if (sum % 2 == 0)
                {
                    claimedItems.Add(sum);
                    firstLootBox.RemoveAt(0);
                    secondLootBox.RemoveAt(secondLootBox.Count - 1);
                }
                else
                {
                    firstLootBox.Add(second);
                    secondLootBox.RemoveAt(secondLootBox.Count - 1);
                }
            }
            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int itemsSum = claimedItems.Sum();
            
            if (itemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {itemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {itemsSum}");
            }
        }
    }
}
