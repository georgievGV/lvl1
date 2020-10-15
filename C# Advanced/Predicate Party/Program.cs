using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            Func<string, string, bool> checkIfStartsWith = (x, y) => x.StartsWith(y);
            Func<string, string, bool> checkIfEndsWith = (x, y) => x.EndsWith(y);
            Func<string, string, bool> checkLength = (x, y) => x.Length == int.Parse(y);


            while (command != "Party!")
            {
                string[] commandInfo = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandInfo[0];
                string checking = commandInfo[1];
                string sample = commandInfo[2];

                if (commandInfo[0] == "Remove")
                {
                    if (commandInfo[1] == "StartsWith")
                    {
                        RemoveIfStartsOrEnds(guests, checkIfStartsWith, sample);
                    }
                    else if (commandInfo[1] == "EndsWith")
                    {
                        RemoveIfStartsOrEnds(guests, checkIfEndsWith, sample);
                    }
                    else if (commandInfo[1] == "Length")
                    {
                        RemoveIfStartsOrEnds(guests, checkLength, sample);
                    }
                }
                else if (commandInfo[0] == "Double")
                {
                    if (commandInfo[1] == "StartsWith")
                    {
                        DoubleIfStartsOrEnds(guests, checkIfStartsWith, sample);
                    }
                    else if (commandInfo[1] == "EndsWith")
                    {
                        DoubleIfStartsOrEnds(guests, checkIfEndsWith, sample);

                    }
                    else if (commandInfo[1] == "Length")
                    {
                        DoubleIfStartsOrEnds(guests, checkLength, sample);
                    }
                }

                command = Console.ReadLine();
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{String.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        private static void DoubleIfStartsOrEnds(List<string> guests, Func<string, string, bool> check, string sample)
        {
            List<string> matchedNames = guests
                                        .Where(x => check(x, sample)).Distinct().ToList();
            foreach (var name in matchedNames)
            {
                int index = 0;
                while (index != guests.Count)
                {
                    index = guests.IndexOf(name, index);
                    if (index == -1)
                    {
                        break;
                    }
                    guests.Insert(index, name);
                    index += 2;
                }
            }
        }

        private static void RemoveIfStartsOrEnds(List<string> guests, Func<string, string, bool> check, string sample)
        {
            List<string> matchedNames = guests
                                        .Where(x => check(x, sample)).ToList();
            foreach (var name in matchedNames)
            {
                if (guests.Contains(name))
                {
                    guests.RemoveAll(x => x == name);
                }
            }
        }
    }
}
