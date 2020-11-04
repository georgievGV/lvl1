using System;
using System.Collections.Generic;
using System.Linq;

using ShoppingSpree.Model;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private const string itemBoughtMessage = "{0} bought {1}";
        private const string itemCantAffordMessage = "{0} can't afford {1}";

        private List<Person> personList;
        private List<Product> productList;

        public Engine()
        {
            personList = new List<Person>();
            productList = new List<Product>();
        }



        public void Run()
        {
            try
            {
                ParsePersonInfo();

                ParseProductInfo();

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = commandInfo[0];
                    string productName = commandInfo[1];

                    if (personList.Exists(x => x.Name == personName)
                        && productList.Exists(x => x.Name == productName))
                    {

                        Person currentPerson = personList.First(x => x.Name == personName);
                        Product currentProduct = productList.First(x => x.Name == productName);
                        Console.WriteLine(BuyProduct(currentPerson, currentProduct));
                    }

                    command = Console.ReadLine();
                }

                foreach (var person in personList)
                {
                    if (person.Bag.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought ");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - {String.Join(", ", person.Bag)}");
                    }
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            

        }

        private string BuyProduct(Person currentPerson, Product currentProduct)
        {
            if (currentPerson.Money >= currentProduct.Cost)
            {
                currentPerson.Money -= currentProduct.Cost;
                currentPerson.AddProduct(currentProduct);

                return string.Format(itemBoughtMessage, currentPerson.Name, currentProduct.Name);
            }
            else
            {
                return string.Format(itemCantAffordMessage, currentPerson.Name, currentProduct.Name);
            }
        }

        private void ParsePersonInfo()
        {
            string[] persons = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < persons.Length; i++)
            {
                string[] personInfo = persons[i].Split("=");
                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                Person person = new Person(name, money);
                this.personList.Add(person);
            }
        }

        private void ParseProductInfo()
        {
            string[] products = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < products.Length; i++)
            {
                string[] productInfo = products[i].Split("=");
                string name = productInfo[0];
                decimal cost = decimal.Parse(productInfo[1]);

                Product product = new Product(name, cost);
                this.productList.Add(product);

            }
        }
    }
}
