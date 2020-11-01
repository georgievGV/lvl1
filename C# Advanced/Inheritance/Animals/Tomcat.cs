using System;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string defaultGender = "Male";

        public Tomcat(string name, int age)
            : base(name, age, defaultGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Tomcat");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            return result.ToString().TrimEnd();
        }
    }
}
