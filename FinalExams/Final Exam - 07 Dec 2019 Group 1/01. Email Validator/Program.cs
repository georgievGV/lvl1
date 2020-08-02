using System;
using System.Linq;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string input = Console.ReadLine();


            while (input != "Complete")
            {
                string[] command = input.Split();

                if (command[0] == "Make")
                {
                    if (command[1] == "Upper")
                    {
                        email = email.ToUpper();
                        Console.WriteLine(email);
                    }
                    else if (command[1] == "Lower")
                    {
                        email = email.ToLower();
                        Console.WriteLine(email);
                    }
                }
                else if (command[0] == "GetDomain")
                {
                    int count = int.Parse(command[1]);
                    string substring = email.Substring(email.Length - count, count);
                    Console.WriteLine(substring);
                }
                else if (command[0] == "GetUsername")
                {
                    if (email.Contains('@'))
                    {
                        int index = email.IndexOf('@');
                        string username = email.Substring(0, index);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (command[0] == "Replace")
                {
                    char oldChar = char.Parse(command[1]);
                    char newChar = '-';
                    email = email.Replace(oldChar, newChar);
                    Console.WriteLine(email);
                }
                else if (command[0] == "Encrypt")
                {
                    char[] chars = email.ToCharArray();
                    int[] nums = chars.Select(x => (int)char.Parse(x.ToString())).ToArray();
                    Console.WriteLine(String.Join(" ", nums));
                }


                input = Console.ReadLine();
            }
        }
    }
}
