using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;
        public string Name { get; private set; }
        public int Capacity { get; }
        public int Count => roster.Count;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>(capacity);
        }

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.Find(x => x.Name == name));
        }
        public void PromotePlayer(string name)
        {
            roster.Find(p => p.Name == name).Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            roster.Find(p => p.Name == name).Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string pClass)
        {
            Player[] kicked = roster.Where(p => p.Class == pClass).ToArray();
            
            roster.RemoveAll(p => p.Class == pClass);
            
            return kicked;
        }
        public string Report()
        {
            if (Count > 0)
            {
                StringBuilder result = new StringBuilder();
                result.Append($"Players in the guild: {Name}\n");

                foreach (Player player in roster)
                {
                    result.Append($"{player}\n");
                }
                return result.ToString();
            }
            return "";
        }
    }
}
