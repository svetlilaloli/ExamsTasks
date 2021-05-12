namespace Opening
{
    public class Employee
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }
        public Employee(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }
        public override string ToString()
        {
            return $"Employee: {Name}, {Age} ({Country})";
        }
    }
}
