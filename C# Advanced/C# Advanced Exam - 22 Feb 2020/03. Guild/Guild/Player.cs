using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string @class)
        {
            Name = name;
            Class = @class;
        }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; } = "Trial";

        public string Description { get; set; } = "n/a";

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Player {Name}: {Class}");
            result.AppendLine($"Rank: {Rank}");
            result.AppendLine($"Description: {Description}");

            return result.ToString().TrimEnd();
        }
    }
}
