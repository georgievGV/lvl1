using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Record> followersRecords =
                new Dictionary<string, Record>();

            while (input != "Log out")
            {
                string[] command = input.Split(": ");

                if (command[0] == "New follower")
                {
                    string username = command[1];
                    if (!followersRecords.ContainsKey(username))
                    {
                        followersRecords.Add(username, new Record(0, 0));
                    }
                }
                else if (command[0] == "Like")
                {
                    string username = command[1];
                    int count = int.Parse(command[2]);

                    if (followersRecords.ContainsKey(username))
                    {
                        followersRecords[username].Likes += count;
                    }
                    else
                    {
                        followersRecords.Add(username, new Record(count, 0));
                    }
                }
                else if (command[0] == "Comment")
                {
                    string username = command[1];

                    if (followersRecords.ContainsKey(username))
                    {
                        followersRecords[username].Comments += 1;
                    }
                    else
                    {
                        followersRecords.Add(username, new Record(0, 1));
                    }
                }
                else if (command[0] == "Blocked")
                {
                    string username = command[1];

                    if (followersRecords.ContainsKey(username))
                    {
                        followersRecords.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
                input = Console.ReadLine();
            }

            followersRecords = followersRecords.OrderByDescending(x => x.Value.Likes)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{followersRecords.Count} followers");
            foreach (var items in followersRecords)
            {
                Console.WriteLine($"{items.Key}: {items.Value.Comments+items.Value.Likes}");
            }
        }
    }

    class Record
    {
        public int Likes { get; set; }
        public int Comments { get; set; }

        public Record(int likes, int comments)
        {
            Comments = comments;
            Likes = likes;
        }
    }
}
