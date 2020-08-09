using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();


            while (line != "END")
            {
                string[] command = line.Split("->");

                if (command[0] == "Add")
                {
                    string store = command[1];
                    string item = command[2];
                    if (item.Contains(','))
                    {
                        string[] items = item.Split(",");

                        if (stores.ContainsKey(store))
                        {
                            for (int i = 0; i < items.Length; i++)
                            {
                                stores[store].Add(items[i]);
                            }
                        }
                        else
                        {
                            stores.Add(store, new List<string>(items.ToList()));
                        }
                    }
                    else
                    {
                        if (stores.ContainsKey(store))
                        {
                            stores[store].Add(item);
                        }
                        else
                        {
                            stores.Add(store, new List<string> { item });
                        }
                    }
                }
                else if (command[0] == "Remove")
                {
                    string store = command[1];

                    if (stores.ContainsKey(store))
                    {
                        stores.Remove(store);
                    }
                }


                line = Console.ReadLine();
            }

            stores = stores.OrderByDescending(x => x.Value.Count)
                .ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Stores list:");

            foreach (var store in stores)
            {
                Console.WriteLine(store.Key);
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
