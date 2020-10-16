using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<string, int, bool> isLarger = (name, number)
                => name.Sum(x => x) >= number;
            Func<List<string>, Func<string, int, bool>, string> checkNames =
                (inputNames, isLargerFilter)
               => inputNames.FirstOrDefault(x=> isLargerFilter(x, n));
            Console.WriteLine(checkNames(names, isLarger));
            
        }
    }
}
