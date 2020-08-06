using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();

            while (line != "END")
            {
                string[] command = line.Split("->");

                if (command[0] == "Add")
                {
                    string road = command[1];
                    string racer = command[2];

                    if (info.ContainsKey(road))
                    {
                        info[road].Add(racer);
                    }
                    else
                    {
                        info.Add(road, new List<string> { racer });
                    }
                }
                else if (command[0] == "Move")
                {
                    string currentRoad = command[1];
                    string racer = command[2];
                    string nextRoad = command[3];

                    if (info[currentRoad].Contains(racer))
                    {
                        info[currentRoad].Remove(racer);
                        info[nextRoad].Add(racer);
                    }
                }
                else if (command[0] == "Close")
                {
                    string road = command[1];

                    if (info.ContainsKey(road))
                    {
                        info.Remove(road);
                    }
                }


                line = Console.ReadLine();
            }

            info = info.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Practice sessions:");

            foreach (var items in info)
            {
                Console.WriteLine(items.Key);
                foreach (var item in items.Value)
                {
                    Console.WriteLine($"++{item}");
                }
            }
        }
    }
}
