using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Regex regex = new Regex(@"([=\/])([A-Z][A-Za-z]{2,})\1");
            MatchCollection mc = regex.Matches(line);
            List<string> locations = new List<string>();

            int travelPoints = 0;
            foreach (Match match in mc)
            {
                locations.Add(match.Groups[2].Value);
                travelPoints += match.Groups[2].Value.Length;
            }

            Console.Write("Destinations: ");
            Console.WriteLine(String.Join(", ", locations));
            Console.WriteLine($"Travel Points: {travelPoints}");

        }
    }
}
