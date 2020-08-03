using System;
using System.Text.RegularExpressions;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"^(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$");


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    string nums = regex.Match(input).Groups[2].Value;
                    string lower = regex.Match(input).Groups[3].Value;
                    string upper = regex.Match(input).Groups[4].Value;
                    string symbols = regex.Match(input).Groups[5].Value;
                    string password = string.Concat(nums, lower, upper, symbols);
                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
