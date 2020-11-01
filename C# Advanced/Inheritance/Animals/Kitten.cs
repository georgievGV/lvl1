using System;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string defaultGender = "female";

        public Kitten(string name, int age)
            : base(name, age, defaultGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Kitten");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            return result.ToString().TrimEnd();
        }

    }
}
