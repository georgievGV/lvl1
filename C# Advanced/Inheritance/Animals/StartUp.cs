using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();


            while (input != "Beast!")
            {
                string animalType = input;
                string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (animalInfo.Length == 3)
                {

                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = animalInfo[2];

                    if (age < 0 || gender != "Female" && gender != "Male")
                    {
                        Console.WriteLine("Invalid input!");
                        input = Console.ReadLine();
                        continue;
                    }

                    Animal animal = null;

                    switch (animalType)
                    {
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;

                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;

                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;

                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;

                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;
                    }

                    animals.Add(animal);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
