namespace CocktailParty
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Cocktail
    {
        private readonly List<Ingredient> ingredients;
        public string Name { get; private set; }
        public int Capacity { get; }
        public int MaxAlcoholLevel { get; private set; }
        public int CurrentAlcoholLevel
        {
            get
            {
                if (ingredients.Count > 0)
                {
                    // NEED IMPROVEMENT
                    return ingredients.Sum(x => x.Alcohol) / ingredients.Count;
                }
                return default;
            }
        }
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            ingredients = new List<Ingredient>(capacity);
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }
        public void Add(Ingredient ingredient)
        {
            var found = ingredients.Find(i => i.Name == ingredient.Name);
            if (found == null
                && ingredients.Count < Capacity
                && CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            return ingredients.Remove(ingredients.Find(i => i.Name == name));
        }
        public Ingredient FindIngredient(string name)
        {
            return ingredients.Find(i => i.Name == name);
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.Find(i => i.Alcohol == ingredients.Max(a => a.Alcohol));
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (Ingredient ingr in ingredients)
            {
                result.Append($"\n{ingr}");
            }
            return result.ToString();
        }
    }
}
