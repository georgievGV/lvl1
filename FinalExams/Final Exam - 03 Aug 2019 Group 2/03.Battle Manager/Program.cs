using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Person> ppl = new Dictionary<string, Person>();

            while (input != "Results")
            {
                string[] command = input.Split(":");

                if (command[0] == "Add")
                {
                    string name = command[1];
                    int health = int.Parse(command[2]);
                    int energy = int.Parse(command[3]);

                    if (ppl.ContainsKey(name))
                    {
                        ppl[name].Health += health;
                    }
                    else
                    {
                        ppl.Add(name, new Person(health, energy));
                    }
                }
                else if (command[0] == "Attack")
                {
                    string attackerName = command[1];
                    string defenderName = command[2];
                    int damage = int.Parse(command[3]);

                    if (ppl.ContainsKey(attackerName) && ppl.ContainsKey(defenderName))
                    {
                        ppl[defenderName].Health -= damage;
                        ppl[attackerName].Energy -= 1;

                        if (ppl[defenderName].Health <= 0)
                        {
                            ppl.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        if (ppl[attackerName].Energy == 0)
                        {
                            ppl.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }
                else if (command[0] == "Delete")
                {
                    string name = command[1];

                    if (name == "All")
                    {
                        ppl.Clear();
                    }
                    else if (ppl.ContainsKey(name))
                    {
                        ppl.Remove(name);
                    }
                }


                input = Console.ReadLine();
            }

            ppl = ppl.OrderByDescending(x => x.Value.Health)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"People count: {ppl.Count}");

            foreach (var items in ppl)
            {
                Console.WriteLine($"{items.Key} - {items.Value.Health}" +
                    $" - {items.Value.Energy}");
            }
        }
    }
    
    class Person
    {
        public int Health { get; set; }
        public int Energy { get; set; }

        public Person(int healt, int energy)
        {
            Health = healt;
            Energy = energy;
        }
    }
}
