using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(\*\*|::)([A-Z][a-z]{2,})\1");
            MatchCollection nums = Regex.Matches(input, @"\d");
            MatchCollection emojiMatches = regex.Matches(input);
            List<string> emojis = new List<string>();
            BigInteger coolThreshold = 1;

            foreach (Match match in nums)
            {
                coolThreshold *= int.Parse(match.Value);
            }

            foreach (Match match in emojiMatches)
            {
                string letters = match.Groups[2].Value;
                int threshold = 0;

                for (int i = 0; i < letters.Length; i++)
                {
                    threshold += letters[i];
                }

                if (threshold > coolThreshold)
                {
                    emojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            if (emojis.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, emojis));
            }
        }
    }
}
