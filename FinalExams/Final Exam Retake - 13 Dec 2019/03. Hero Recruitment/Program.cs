using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> heroesList = new Dictionary<string, List<string>>();

            while (input != "End")
            {
                string[] command = input.Split();

                if (command[0] == "Enroll")
                {

                    string name = command[1];
                    if (heroesList.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} is already enrolled.");
                    }
                    else
                    {
                        heroesList.Add(name, new List<string>());
                    }

                }

                else if (command[0] == "Learn")
                {
                    string name = command[1];
                    string spellName = command[2];

                    if (heroesList.ContainsKey(name))
                    {
                        if (heroesList[name].Contains(spellName))
                        {
                            Console.WriteLine($"{name} has already learnt {spellName}.");
                        }
                        else
                        {
                            heroesList[name].Add(spellName);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                }

                else if (command[0] == "Unlearn")
                {
                    string name = command[1];
                    string spellName = command[2];

                    if (heroesList.ContainsKey(name))
                    {
                        if (heroesList[name].Contains(spellName))
                        {
                            heroesList[name].Remove(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{name} doesn't know {spellName}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                }

                input = Console.ReadLine();
            }

            heroesList = heroesList.OrderByDescending(x => x.Value.Count)
                .ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Heroes:");
            foreach (var items in heroesList)
            {
                Console.Write($"== {items.Key}: ");
                Console.WriteLine(String.Join(", ", items.Value));
            }
        }
    }
}
