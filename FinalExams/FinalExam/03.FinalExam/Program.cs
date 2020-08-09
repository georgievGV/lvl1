using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                string[] info = input.Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = info[0];
                int rarity = int.Parse(info[1]);
                Plant current = new Plant(rarity, new List<int>());

                if (plants.ContainsKey(plant))
                {
                    plants[plant].Rarity = rarity;
                }
                else
                {
                    plants.Add(plant, current);
                }

            }

            string line = Console.ReadLine();

            while (line != "Exhibition")
            {
                string[] commandInfo = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string command = commandInfo[0].Trim();

                if (command == "Rate")
                {
                    string[] plantInfo = commandInfo[1].Split("-", StringSplitOptions.RemoveEmptyEntries);
                    string plant = plantInfo[0].Trim();
                    int rating = int.Parse(plantInfo[1]);

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Rating.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "Update")
                {
                    string[] plantInfo = commandInfo[1].Split("-", StringSplitOptions.RemoveEmptyEntries);
                    string plant = plantInfo[0].Trim();
                    int newRarity = int.Parse(plantInfo[1]);

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "Reset")
                {
                    string plant = commandInfo[1].Trim();

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Rating.Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }

                line = Console.ReadLine();
            }

            Dictionary<string, Final> final = new Dictionary<string, Final>();

            foreach (var item in plants)
            {
                string plant = item.Key;
                int rarity = item.Value.Rarity;
                double avrRating = 0;
                if (item.Value.Rating.Count > 0)
                {
                    avrRating = item.Value.Rating.Average();
                }
                Final current = new Final(rarity, avrRating);
                final.Add(plant, current);
            }

            final = final.OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.AvrRating)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in final)
            {
                string plant = item.Key;
                int rarity = item.Value.Rarity;
                double avrRating = item.Value.AvrRating;

                Console.WriteLine($"- {plant}; Rarity: {rarity}; Rating: {avrRating:f2}");
            }

        }
    }
    class Plant
    {
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }

        public Plant(int rarity, List<int> rating)
        {
            Rarity = rarity;
            Rating = rating;
        }
    }
    class Final
    {
        public int Rarity { get; set; }
        public double AvrRating { get; set; }

        public Final(int rarity, double avrRating)
        {
            Rarity = rarity;
            AvrRating = avrRating;
        }
    }
}
