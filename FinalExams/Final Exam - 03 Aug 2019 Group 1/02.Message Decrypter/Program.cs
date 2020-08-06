using System;
using System.Text.RegularExpressions;

namespace _02.Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Regex regex = 
                new Regex(@"^(%|\$)([A-Z][a-z]{2,})\1:\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$");

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    string tag = regex.Match(input).Groups[2].Value;
                    char charOne = (char)int.Parse(regex.Match(input).Groups[3].Value);
                    char charTwo = (char)int.Parse(regex.Match(input).Groups[4].Value);
                    char charThree = (char)int.Parse(regex.Match(input).Groups[5].Value);

                    Console.WriteLine($"{tag}: {charOne}{charTwo}{charThree}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
