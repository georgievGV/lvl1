using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Band> bands = new Dictionary<string, Band>();


            while (input != "start of concert")
            {
                string[] command = input.Split("; ");

                if (command[0] == "Add")
                {
                    string name = command[1];
                    string[] members = command[2].Split(", ");

                    if (bands.ContainsKey(name))
                    {
                        for (int i = 0; i < members.Length; i++)
                        {
                            if (!bands[name].Members.Contains(members[i]))
                            {
                                bands[name].Members.Add(members[i]);
                            }
                        }
                    }
                    else
                    {
                        Band currentBand = new Band(new List<string>(members), 0);
                        bands.Add(name, currentBand);
                    }
                }
                else if (command[0] == "Play")
                {
                    string name = command[1];
                    int time = int.Parse(command[2]);

                    if (bands.ContainsKey(name))
                    {
                        bands[name].BandTime += time;
                    }
                    else
                    {
                        Band currentBand = new Band(new List<string>(), time);
                        bands.Add(name, currentBand);
                    }
                }


                input = Console.ReadLine();
            }

            Dictionary<string, Band> bandsOrdered = bands.OrderByDescending(x => x.Value.BandTime)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            int totalTime = bands.Sum(x => x.Value.BandTime);
            string bandName = Console.ReadLine();

            Console.WriteLine($"Total time: {totalTime}");

            foreach (var items in bandsOrdered)
            {
                Console.WriteLine($"{items.Key} -> {items.Value.BandTime}");
            }

            Console.WriteLine(bandName);
            foreach (var item in bands[bandName].Members)
            {
                Console.WriteLine($"=> {item}");
            }
        }

    }

    class Band
    {
        public List<string> Members { get; set; }
        public int BandTime { get; set; }

        public Band(List<string> members, int bandTime)
        {
            Members = members;
            BandTime = bandTime;
        }
    }
}
