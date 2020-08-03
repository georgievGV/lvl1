using System;
using System.Text.RegularExpressions;

namespace _02.Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"(\*|\@)([A-Z][a-z]{2,})\1:\s\[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|$");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    string tag = regex.Match(input).Groups[2].Value;
                    Console.Write($"{tag}: ");
                    for (int j = 3; j <= 5; j++)
                    {
                        Console.Write($"{(int)char.Parse(regex.Match(input).Groups[j].Value)} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
