using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> guestPreferences = 
                new Dictionary<string, List<string>>();
            int unlikedMeals = 0;

            while (input != "Stop")
            {
                string[] command = input.Split("-");

                if (command[0] == "Like")
                {
                    string guest = command[1];
                    string meal = command[2];

                    if (guestPreferences.ContainsKey(guest))
                    {
                        if (!guestPreferences[guest].Contains(meal))
                        {
                            guestPreferences[guest].Add(meal);
                        }
                    }
                    else
                    {
                        guestPreferences.Add(guest, new List<string> { meal });
                    }
                }
                else if (command[0] == "Unlike")
                {
                    string guest = command[1];
                    string meal = command[2];

                    if (guestPreferences.ContainsKey(guest))
                    {
                        if (guestPreferences[guest].Contains(meal))
                        {
                            //int unliked = guestPreferences[guest].IndexOf(meal);
                            guestPreferences[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            unlikedMeals++;
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} " +
                                $"in his/her collection.");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                }



                input = Console.ReadLine();
            }

            guestPreferences = guestPreferences.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var items in guestPreferences)
            {
                Console.Write($"{items.Key}: ");
                Console.WriteLine(String.Join(", ", items.Value));
            }
            Console.WriteLine($"Unliked meals: {unlikedMeals}");

        }
    }
}
