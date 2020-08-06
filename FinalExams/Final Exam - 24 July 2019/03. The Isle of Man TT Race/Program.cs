using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Regex regex = new Regex(@"([#$%*&])([A-Za-z]+)\1=(\d+)!!(.*)");

            while (true)
            {
                if (regex.IsMatch(line))
                {
                    string name = regex.Match(line).Groups[2].Value;
                    int length = int.Parse(regex.Match(line).Groups[3].Value);
                    string code = regex.Match(line).Groups[4].Value;

                    if (length == code.Length)
                    {
                        string newCode = string.Empty;
                        for (int i = 0; i < length; i++)
                        {
                            newCode += (char)(code[i] + length);
                        }

                        Console.WriteLine($"Coordinates found! {name} -> {newCode}");
                        break;
                    }
                }

                Console.WriteLine("Nothing found!");
                line = Console.ReadLine();
            }
        }
    }
}
