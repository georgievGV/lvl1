using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            Item = item;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Hero: {Name} - {Level}lvl");
            result.AppendLine($"Item:");
            result.AppendLine($"    * Strength: {Item.Strength}");
            result.AppendLine($"    * Ability: {Item.Ability}");
            result.AppendLine($"    * Intelligence: {Item.Intelligence}");

            return result.ToString().TrimEnd();
        }
    }
}
