using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> usersEmails = new Dictionary<string, List<string>>();


            while (input != "Statistics")
            {
                string[] command = input.Split("->");

                if (command[0] == "Add")
                {
                    string username = command[1];
                    if (usersEmails.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    else
                    {
                        usersEmails.Add(username, new List<string>());
                    }
                }
                else if (command[0] == "Send")
                {
                    string username = command[1];
                    string email = command[2];

                    usersEmails[username].Add(email);
                }
                else if (command[0] == "Delete")
                {
                    string username = command[1];

                    if (usersEmails.ContainsKey(username))
                    {
                        usersEmails.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
                input = Console.ReadLine();
            }

            usersEmails = usersEmails.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Users count: {usersEmails.Count}");
            foreach (var items in usersEmails)
            {
                Console.WriteLine($"{items.Key}");
                foreach (var item in items.Value)
                {
                    Console.WriteLine($"- {item}");
                }
            }

        }
    }
}
