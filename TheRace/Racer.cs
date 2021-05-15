﻿namespace TheRace
{
    public class Racer
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }
        public Car Car { get; private set; }
        public Racer(string name, int age, string country, Car car)
        {
            Name = name;
            Age = age;
            Country = country;
            Car = car;
        }
        public override string ToString()
        {
            return $"Racer: {Name}, {Age} ({Country})";
        }
    }
}
