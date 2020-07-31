using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"([@#])([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1");
            MatchCollection mc = regex.Matches(input);
            List<string> pairs = new List<string>();

            foreach (Match match in mc)
            {
                pairs.Add(match.Groups[2].Value);
                pairs.Add(match.Groups[3].Value);
            }

            List<string> mirrorWords = new List<string>();

            for (int i = 1; i < pairs.Count; i += 2)
            {
                char[] letters = pairs[i].ToCharArray();
                Array.Reverse(letters);
                string word = new string(letters);
                if (pairs[i - 1] == word)
                {
                    string pair = $"{pairs[i - 1]} <=> {pairs[i]}";
                    mirrorWords.Add(pair);
                }

            }

            if (pairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{pairs.Count / 2} word pairs found!");
            }

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}
