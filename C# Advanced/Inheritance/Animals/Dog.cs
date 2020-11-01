using System;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Dog");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            return result.ToString().TrimEnd();
        }
    }
}
