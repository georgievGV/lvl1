using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    string command = regex.Match(input).Groups[1].Value;
                    string message = regex.Match(input).Groups[2].Value;
                    int[] nums = message.Select(x => (int)char.Parse(x.ToString())).ToArray();
                    Console.Write($"{command}: ");
                    Console.WriteLine(String.Join(" ", nums));
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
