using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private readonly List<Racer> data;
        public string Name { get; private set; }
        public int Capacity { get; }
        public int Count => data.Count;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>(capacity);
        }
        public void Add(Racer racer)
        {
            if (Count < Capacity)
            {
                data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            return data.Remove(data.Find(r => r.Name == name));
        }
        public Racer GetOldestRacer()
        {
            return data.Find(r => r.Age == data.Max(a => a.Age));
        }
        public Racer GetRacer(string name)
        {
            return data.Find(r => r.Name == name);
        }
        public Racer GetFastestRacer()
        {
            return data.Find(r => r.Car.Speed == data.Max(s => s.Car.Speed));
        }
        public string Report() 
        {
            StringBuilder result = new StringBuilder();
            if (Count > 0)
            {
                result.Append($"Racers participating at {Name}:");

                foreach (Racer racer in data)
                {
                    result.Append($"\n{racer}");
                }
                return result.ToString();
            }
            return null;
        }
    }
}
