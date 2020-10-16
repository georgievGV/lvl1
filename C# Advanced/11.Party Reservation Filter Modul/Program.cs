using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string filter = Console.ReadLine();
            List<string[]> filterList = new List<string[]>();

            while (filter != "Print")
            {
                string[] filterInfo = filter
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                string filterType = filterInfo[0];
                string condition = filterInfo[1];
                string pattern = filterInfo[2];

                if (filterType == "Remove filter")
                {
                    if (filterList.Contains(new string[3] { "Add filter", condition, pattern })) ;
                    {
                        int index = filterList.FindIndex(i => i.SequenceEqual(new string[3] { "Add filter", condition, pattern }));
                        filterList.RemoveAt(index);
                    }
                }
                if (filterType == "Add filter")
                {
                    filterList.Add(new string[3] { "Add filter", condition, pattern });
                }

                filter = Console.ReadLine();
            }

            Func<string, string, bool> checkIfStartsWith = (x, y) => x.StartsWith(y);
            Func<string, string, bool> checkIfEndsWith = (x, y) => x.EndsWith(y);
            Func<string, string, bool> checkLength = (x, y) => x.Length == int.Parse(y);
            Func<string, string, bool> checkIfContains = (x, y) => x.Contains(y);

            foreach (var currFilter in filterList)
            {
                string currCondition = currFilter[1];
                string currPattern = currFilter[2];

                switch (currCondition)
                {
                    case "Starts with":
                        guests = guests.Where(x => !checkIfStartsWith(x, currPattern)).ToList();
                        break;
                    case "Ends with":
                        guests = guests.Where(x => !checkIfEndsWith(x, currPattern)).ToList();
                        break;
                    case "Length":
                        guests = guests.Where(x => !checkLength(x, currPattern)).ToList();
                        break;
                    case "Contains":
                        guests = guests.Where(x => !checkIfContains(x, currPattern)).ToList();
                        break;
                }

            }
            Console.WriteLine(String.Join(" ", guests));
        }
    }
}
