namespace TheRace
{
    public class Car
    {
        public string Name { get; private set; }
        public int Speed { get; private set; }
        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }
    }
}
