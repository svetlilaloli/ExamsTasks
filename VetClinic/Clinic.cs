namespace VetClinic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Clinic
    {
        private List<Pet> data;
        public int Capacity { get; set; }
        public Clinic(int capacity)
        {
            data = new List<Pet>(capacity);
        }
        public int Count => data.Count;
        public void Add(Pet pet)
        {
            data.Add(pet);
        }
        public bool Remove(string name)
        {
            int result = data.RemoveAll(p => p.Name == name);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            return data.Find(p => p.Name == name && p.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            return data.Find(x => x.Age == data.Max(p => p.Age));
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.Append("The clinic has the following patients:");

            foreach (Pet pet in data)
            {
                result.Append($"\nPet {pet.Name}\nwith owner: {pet.Owner}");
            }
            return result.ToString();
        }
    }
}
