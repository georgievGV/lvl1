using System;
using System.Linq;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMsg = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Finish")
            {
                string[] commandDetail = input.Split();
                string command = commandDetail[0];

                if (command == "Replace")
                {
                    char oldChar = char.Parse(commandDetail[1]);
                    char newChar = char.Parse(commandDetail[2]);
                    encryptedMsg = encryptedMsg.Replace(oldChar, newChar);
                    Console.WriteLine(encryptedMsg);
                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(commandDetail[1]);
                    int endIndex = int.Parse(commandDetail[2]);

                    if (startIndex >= 0 && endIndex < encryptedMsg.Length)
                    {
                        encryptedMsg = encryptedMsg.Remove(startIndex, (endIndex - startIndex) + 1);
                        Console.WriteLine(encryptedMsg);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (command == "Make")
                {
                    string lowerUpper = commandDetail[1];

                    if (lowerUpper == "Lower")
                    {
                        encryptedMsg = encryptedMsg.ToLower();
                    }
                    else if (lowerUpper == "Upper")
                    {
                        encryptedMsg = encryptedMsg.ToUpper();
                    }
                    Console.WriteLine(encryptedMsg);
                }
                else if (command == "Check")
                {
                    string substring = commandDetail[1];

                    if (encryptedMsg.Contains(substring))
                    {
                        Console.WriteLine($"Message contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {substring}");
                    }
                }
                else if (command == "Sum")
                {
                    int startIndex = int.Parse(commandDetail[1]);
                    int endIndex = int.Parse(commandDetail[2]);
                    string substring = string.Empty;
                    int sum = 0;

                    if (startIndex >= 0 && endIndex < encryptedMsg.Length)
                    {
                        substring = encryptedMsg.Substring(startIndex, endIndex);
                        char[] letters = substring.ToCharArray();
                        sum = letters.Sum(x => x);
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }


                input = Console.ReadLine();
            }
        }
    }
}
