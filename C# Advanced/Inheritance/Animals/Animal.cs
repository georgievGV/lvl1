using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get;}

        public int Age { get;}

        public string Gender { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Animal");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            return result.ToString().TrimEnd();
        }

        public virtual string ProduceSound()
        {
            return "";
        }
    }
}
