namespace Guild
{
    public class Player
    {
        public string Name { get; private set; }
        public string Class { get; private set; }
        public string Rank { get; internal set; }
        public string Description { get; set; }

        public Player(string name, string pClass)
        {
            Name = name;
            Class = pClass;
            Rank = "Trial";
            Description = "n/a";
        }
        public override string ToString()
        {
            return $"Player { Name}: { Class}\nRank: { Rank}\nDescription: { Description}";
        }
    }
}
