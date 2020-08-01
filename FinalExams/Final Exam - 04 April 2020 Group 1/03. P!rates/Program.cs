using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, City> cities = new Dictionary<string, City>();

            while (input != "Sail")
            {
                string[] cityInfo = input.Split("||");
                string name = cityInfo[0];
                int population = int.Parse(cityInfo[1]);
                int gold = int.Parse(cityInfo[2]);

                City currentCity = new City(population, gold);
                if (!cities.ContainsKey(name))
                {
                    cities.Add(name, currentCity);
                }
                else
                {
                    cities[name].Gold += gold;
                    cities[name].Population += population;
                }

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandDetails = command.Split("=>");

                if (commandDetails[0] == "Plunder")
                {
                    string city = commandDetails[1];
                    int ppl = int.Parse(commandDetails[2]);
                    int gold = int.Parse(commandDetails[3]);

                    cities[city].Gold -= gold;
                    cities[city].Population -= ppl;
                    Console.WriteLine($"{city} plundered! {gold} gold stolen, " +
                        $"{ppl} citizens killed.");

                    if (cities[city].Population <= 0 || cities[city].Gold <= 0)
                    {
                        Console.WriteLine($"{city} has been wiped off the map!");
                        cities.Remove(city);
                    }
                }

                else if (commandDetails[0] == "Prosper")
                {
                    string city = commandDetails[1];
                    int gold = int.Parse(commandDetails[2]);

                    if (gold > 0)
                    {
                        cities[city].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury." +
                            $" {city} now has {cities[city].Gold} gold.");
                    }
                    else if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                }


                command = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                cities = cities.OrderByDescending(x => x.Value.Gold)
                     .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var items in cities)
                {
                    Console.WriteLine($"{items.Key} -> Population: {items.Value.Population} " +
                        $"citizens, Gold: {items.Value.Gold} kg");
                }
            }

        }
    }

    class City
    {
        public int Population { get; set; }
        public int Gold { get; set; }

        public City(int population, int gold)
        {
            Population = population;
            Gold = gold;
        }
    }

}
