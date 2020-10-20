using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            Strength = strength;
            Ability = ability;
            Intelligence = intelligence;
        }

        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Item:");
            result.AppendLine($"    * Strength: {Strength}");
            result.AppendLine($"    * Ability: {Ability}");
            result.AppendLine($"    * Intelligence: {Intelligence}");

            return result.ToString(); 
        }
    }
}
