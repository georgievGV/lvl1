using System;
using System.Linq;

namespace _01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Sign up")
            {
                string[] command = input.Split();

                if (command[0] == "Case")
                {
                    if (command[1] == "lower")
                    {
                        username = username.ToLower();
                        Console.WriteLine(username);
                    }
                    else if (command[1] == "upper")
                    {
                        username = username.ToUpper();
                        Console.WriteLine(username);
                    }
                }
                else if (command[0] == "Reverse")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex >= 0 && endIndex < username.Length)
                    {
                        string substring = username.Substring(startIndex, (endIndex - startIndex) + 1);
                        char[] letters = substring.ToCharArray();
                        Array.Reverse(letters);
                        substring = new string(letters);
                        Console.WriteLine(substring);
                    }
                }
                else if (command[0] == "Cut")
                {
                    string substring = command[1];

                    if (username.Contains(substring))
                    {
                        int index = username.IndexOf(substring);
                        username = username.Remove(index, substring.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }
                else if (command[0] == "Replace")
                {
                    char oldChar = char.Parse(command[1]);
                    char newChar = '*';
                    username = username.Replace(oldChar, newChar);
                    Console.WriteLine(username);
                }
                else if (command[0] == "Check")
                {
                    char givenChar = char.Parse(command[1]);

                    if (username.Contains(givenChar))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {givenChar}.");
                    }
                }


                input = Console.ReadLine();
            }
        }
    }
}
