using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] rosesArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> lilies = new Stack<int>(liliesArray);
            Queue<int> roses = new Queue<int>(rosesArray);
            List<int> flowersLeft = new List<int>();
            int wreaths = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int currLily = lilies.Peek();
                int currRose = roses.Peek();
                int sum = currLily + currRose;

                if (sum > 15)
                {
                    currLily -= 2;
                    lilies.Pop();
                    lilies.Push(currLily);
                }
                else if (sum < 15)
                {
                    flowersLeft.Add(currLily);
                    flowersLeft.Add(currRose);
                    lilies.Pop();
                    roses.Dequeue();
                }
                else
                {
                    lilies.Pop();
                    roses.Dequeue();
                    wreaths++;
                }
            }

            if (flowersLeft.Count > 0)
            {
                int wreathsFromFlowersLeft = flowersLeft.Sum() / 15;
                wreaths += wreathsFromFlowersLeft;
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
