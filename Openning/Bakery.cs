using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openning
{
    public class Bakery
    {
        private readonly List<Employee> data;
        public string  Name { get; private set; }
        public int Capacity { get; }
        public int Count => data.Count;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>(capacity);
        }
        public void Add(Employee employee)
        {
            if (Count < Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            return data.Remove(data.Find(e => e.Name == name));
        }
        public Employee GetOldestEmployee()
        {
            return data.Find(e => e.Age == data.Max(x => x.Age));
        }
        public Employee GetEmployee(string name)
        {
            return data.Find(e => e.Name == name);
        }
        public string Report()
        {
            if (data.Count > 0)
            {
                StringBuilder result = new StringBuilder();
                result.Append($"Employees working at Bakery {Name}:");
                foreach (Employee employee in data)
                {
                    result.Append($"\n{ employee }");
                }
                return result.ToString();
            }
            return null;
        }
    }
}
