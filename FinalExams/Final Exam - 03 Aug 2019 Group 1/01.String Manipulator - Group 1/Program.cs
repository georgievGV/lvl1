using System;

namespace _01.String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string theString = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split();

                if (command[0] == "Translate")
                {
                    char oldChar = char.Parse(command[1]);
                    char newChar = char.Parse(command[2]);

                    theString = theString.Replace(oldChar, newChar);
                    Console.WriteLine(theString);
                }
                else if (command[0] == "Includes")
                {
                    string substring = command[1];

                    if (theString.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command[0] == "Start")
                {
                    string substring = command[1];
                    string checkString = theString.Substring(0, substring.Length);

                    if (substring == checkString)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command[0] == "Lowercase")
                {
                    theString = theString.ToLower();
                    Console.WriteLine(theString);
                }
                else if (command[0] == "FindIndex")
                {
                    char current = char.Parse(command[1]);
                    int index = theString.LastIndexOf(current);
                    Console.WriteLine(index);
                }
                else if (command[0] == "Remove")
                {
                    int startIndex = int.Parse(command[1]);
                    int count = int.Parse(command[2]);

                    theString = theString.Remove(startIndex, count);
                    Console.WriteLine(theString);
                }
                input = Console.ReadLine();
            }
        }
    }
}
