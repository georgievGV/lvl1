using System;
using System.Text.RegularExpressions;

namespace _02._Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\|(?<boss>[A-Z]{4,})\|:#(?<title>[A-Za-z]+\s[A-Za-z]+)#");
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    string boss = regex.Match(input).Groups["boss"].Value;
                    string title = regex.Match(input).Groups["title"].Value;
                    Console.WriteLine($"{boss}, The {title}");
                    Console.WriteLine($">> Strength: {boss.Length}");
                    Console.WriteLine($">> Armour: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }

            }


        }
    }
}
