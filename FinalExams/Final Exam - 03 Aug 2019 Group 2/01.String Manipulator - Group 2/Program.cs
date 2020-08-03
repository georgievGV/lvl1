using System;

namespace _01.String_Manipulator___Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] command = input.Split();

                if (command[0] == "Change")
                {
                    char oldChar = char.Parse(command[1]);
                    char newChar = char.Parse(command[2]);

                    text = text.Replace(oldChar, newChar);
                    Console.WriteLine(text);
                }
                else if (command[0] == "Includes")
                {
                    string substring = command[1];

                    if (text.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command[0] == "End")
                {
                    string substring = command[1];
                    string textSubstring = text.Substring(text.Length - substring.Length, substring.Length);
                    if (substring == textSubstring)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command[0] == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (command[0] == "FindIndex")
                {
                    int index = text.IndexOf(char.Parse(command[1]));
                    Console.WriteLine(index);
                }
                else if (command[0] == "Cut")
                {
                    int startIndex = int.Parse(command[1]);
                    int length = int.Parse(command[2]);
                    string substring = text.Substring(startIndex, length);
                    text = substring;
                    Console.WriteLine(text);

                }
                input = Console.ReadLine();
            }
        }
    }
}
