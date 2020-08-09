using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FInalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string line = Console.ReadLine();


            while (line != "Travel")
            {
                string[] command = line.Split(":");

                if (command[0] == "Add Stop")
                {
                    int index = int.Parse(command[1]);
                    string addString = command[2];

                    if (index >= 0 && index <= stops.Length)
                    {
                        stops = stops.Insert(index, addString);
                    }
                }
                else if (command[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex >= 0 && endIndex < stops.Length)
                    {
                        stops = stops.Remove(startIndex, (endIndex - startIndex) + 1);
                    }
                }
                else if (command[0] == "Switch")
                {
                    string oldString = command[1];
                    string newString = command[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                }

                Console.WriteLine(stops);
                line = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
