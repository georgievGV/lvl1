using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"U\$([A-Z][a-z]{2,})U\$P@\$([A-Za-z]{5,}.*\d)P@\$");
            int successfullRegs = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    string username = regex.Match(input).Groups[1].Value;
                    string password = regex.Match(input).Groups[2].Value;
                    successfullRegs++;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }

            }

            Console.WriteLine($"Successful registrations: {successfullRegs}");
        }
    }
}
