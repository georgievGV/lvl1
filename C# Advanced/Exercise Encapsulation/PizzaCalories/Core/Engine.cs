using System;

using PizzaCalories.Models;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            try
            {
                string command = Console.ReadLine();
                Pizza pizza = new Pizza();

                while (command != "END")
                {
                    string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (info[0] == "Pizza")
                    {
                        pizza.Name = ParseName(info);
                    }
                    else if (info[0] == "Dough")
                    {
                        pizza.Dough = ParseDoughParams(info);
                    }
                    else if (info[0] == "Topping")
                    {
                        pizza.AddTopping(ParseToppingParams(info));
                    }

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        public Dough ParseDoughParams(string[] info)
        {
            Flour flour = new Flour(info[1]);
            BakingTechnique technique = new BakingTechnique(info[2]);
            int grams = int.Parse(info[3]);
            Dough dough = new Dough(flour, technique, grams);

            return dough;
        }

        public Topping ParseToppingParams(string[] info)
        {
            string type = info[1];
            int grams = int.Parse(info[2]);
            Topping topping = new Topping(type, grams);

            return topping;
        }

        public string ParseName(string[] info)
        {
            if (info.Length == 1)
            {
                return null;
            }
            return info[1];
        }
    }
}
