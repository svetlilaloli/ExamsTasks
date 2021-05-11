namespace VetClinic
{
    public class Pet
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string  Owner { get; private set; }
        public Pet(string name, int age, string owner)
        {
            Name = name;
            Age = age;
            Owner = owner;
        }
        public override string ToString()
        {
            return $"Name: {Name} Age: {Age} Owner: {Owner}";
        }
    }
}
