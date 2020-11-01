using System;
using System.Text;

namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Frog");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            return result.ToString().TrimEnd();
        }
    }
}
