namespace Parking
{
    using System.Collections.Generic;
    using System.Text;
    public class Parking
    {
        private readonly List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;
        public Parking(string type, int capacity)
        {
            data = new List<Car>(capacity);
            Type = type;
            Capacity = capacity;
        }
        public void Add(Car car)
        {
            data.Add(car);
        }
        public bool Remove(string manufacturer, string model)
        {
            int removed = data.RemoveAll(c => c.Manufacturer == manufacturer && c.Model == model);
            if (removed > 0)
            {
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (Count > 0)
            {
                return data[Count - 1];
            }
            return null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            return data.Find(c => c.Manufacturer == manufacturer && c.Model == model);
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            
            result.Append($"The cars are parked in { Type}:");

            foreach (Car car in data)
            {
                result.Append($"\n{car}");
            }
            return result.ToString();
        }
    }
}
