using System;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Cat");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            return result.ToString().TrimEnd();
        }
    }
}
