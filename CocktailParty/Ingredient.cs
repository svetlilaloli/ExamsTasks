namespace CocktailParty
{
    public class Ingredient
    {
        public string Name { get; private set; }
        public int Alcohol { get; private set; }
        public int Quantity { get; set; }
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return $"Ingredient: {Name}\nQuantity: { Quantity}\nAlcohol: { Alcohol}";
        }
    }
}
