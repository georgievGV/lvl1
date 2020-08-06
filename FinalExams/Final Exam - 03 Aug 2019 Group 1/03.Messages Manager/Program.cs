using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Dictionary<string, UserMsgs> data = new Dictionary<string, UserMsgs>();

            while (input != "Statistics")
            {
                string[] command = input.Split("=");

                if (command[0] == "Add")
                {
                    string username = command[1];
                    int messagesSent = int.Parse(command[2]);
                    int messagesReceived = int.Parse(command[3]);

                    if (!data.ContainsKey(username))
                    {
                        data.Add(username, new UserMsgs(messagesSent, messagesReceived));
                    }

                }
                else if (command[0] == "Message")
                {
                    string sender = command[1];
                    string receiver = command[2];

                    if (data.ContainsKey(sender) && data.ContainsKey(receiver))
                    {
                        data[sender].MessagesSent++;
                        if (data[sender].MessagesSent + data[sender].MessagesReceived == capacity)
                        {
                            data.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }

                        data[receiver].MessagesReceived++;
                        if (data[receiver].MessagesReceived + data[receiver].MessagesSent == capacity)
                        {
                            data.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }
                else if (command[0] == "Empty")
                {
                    string username = command[1];

                    if (username == "All")
                    {
                        data.Clear();
                    }
                    else if (data.ContainsKey(username))
                    {
                        data.Remove(username);
                    }
                }

                input = Console.ReadLine();
            }

            data = data.OrderByDescending(c => c.Value.MessagesReceived)
                .ThenBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);

            Console.WriteLine($"Users count: {data.Count}");

            foreach (var items in data)
            {
                Console.WriteLine($"{items.Key} - " +
                    $"{items.Value.MessagesReceived + items.Value.MessagesSent}");
            }
        }
    }

    class UserMsgs
    {
        public int MessagesSent { get; set; }
        public int MessagesReceived { get; set; }

        public UserMsgs(int messagesSent, int messagesReceived)
        {
            MessagesSent = messagesSent;
            MessagesReceived = messagesReceived;
        }
    }
}
