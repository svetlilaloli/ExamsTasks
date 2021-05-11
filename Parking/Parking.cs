namespace Parking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Parking
    {
        private readonly List<Car> data;
        public string Type { get; private set; }
        public int Capacity { get; }
        public int Count => data.Count;
        public Parking(string type, int capacity)
        {
            data = new List<Car>(capacity);
            Type = type;
            Capacity = capacity;
        }
        public void Add(Car car)
        {
            if (Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var found = data.Find(c => c.Manufacturer == manufacturer && c.Model == model);
            if (found != null)
            {
                data.Remove(found);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            return data.Find(x => x.Year == data.Max(c => c.Year));
        }
        public Car GetCar(string manufacturer, string model)
        {
            return data.Find(c => c.Manufacturer == manufacturer && c.Model == model);
        }
        public string GetStatistics()
        {
            if (Count > 0)
            {
                StringBuilder result = new StringBuilder();

                result.Append($"The cars are parked in { Type}:");

                foreach (Car car in data)
                {
                    result.Append($"\n{car}");
                }
                return result.ToString();
            }
            return null;
        }
    }
}
