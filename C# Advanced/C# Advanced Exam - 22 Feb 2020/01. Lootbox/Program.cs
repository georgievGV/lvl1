using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(firstInput);
            Stack<int> secondBox = new Stack<int>(secondInput);
            Queue<int> claimedItems = new Queue<int>();

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstNumber = firstBox.Peek();
                int secondNumber = secondBox.Peek();
                int sum = firstNumber + secondNumber;

                if (sum % 2 == 0)
                {
                    claimedItems.Enqueue(firstNumber);
                    claimedItems.Enqueue(secondNumber);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondNumber);
                    secondBox.Pop();
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int totalSum = claimedItems.Sum();
            if (totalSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {totalSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {totalSum}");
            }
        }
    }
}
