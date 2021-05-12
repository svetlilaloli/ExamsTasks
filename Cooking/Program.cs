namespace Cooking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            List<int> liquids = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
            List<int> ingredients = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();

            Dictionary<string, int> cookedFood = new Dictionary<string, int>
            {
                { "Bread", 0 },
                { "Cake", 0 },
                { "Pastry", 0 },
                { "Fruit Pie", 0 }
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int sum = liquids[0] + ingredients[ingredients.Count - 1];

                switch (sum)
                {
                    case 25: 
                        cookedFood["Bread"]++;
                        ingredients.RemoveAt(ingredients.Count - 1);
                        break;
                    case 50: 
                        cookedFood["Cake"]++;
                        ingredients.RemoveAt(ingredients.Count - 1);
                        break;
                    case 75: 
                        cookedFood["Pastry"]++;
                        ingredients.RemoveAt(ingredients.Count - 1);
                        break;
                    case 100: 
                        cookedFood["Fruit Pie"]++;
                        ingredients.RemoveAt(ingredients.Count - 1);
                        break;
                    default:
                        ingredients[ingredients.Count - 1] += 3;
                        break;
                }

                liquids.RemoveAt(0);
            }
            PrintSuccess(cookedFood);
            PrintLiquidsLeft(liquids);
            PrintIngredientsLeft(ingredients);
            PrintCookedFood(cookedFood);
        }

        private static void PrintCookedFood(Dictionary<string, int> cookedFood)
        {
            foreach (var item in cookedFood.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void PrintIngredientsLeft(List<int> ingredients)
        {
            Console.Write("Ingredients left: ");

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", ingredients.OrderBy(x => x))}");
            }
            else
            {
                Console.WriteLine("none");
            }
        }

        private static void PrintLiquidsLeft(List<int> liquids)
        {
            Console.Write("Liquids left: ");

            if (liquids.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("none");
            }
        }

        private static void PrintSuccess(Dictionary<string, int> cookedFood)
        {
            if (cookedFood.ContainsValue(0))
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
        }
    }
}
