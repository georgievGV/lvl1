using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] threadsArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int taskToKill = int.Parse(Console.ReadLine());
            int killThreat = 0;

            Stack<int> tasks = new Stack<int>(tasksArray);
            Queue<int> threads = new Queue<int>(threadsArray);

            while (true)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentTask == taskToKill)
                {
                    killThreat = currentThread;
                    break;
                }

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {killThreat} killed task {taskToKill}");
            if (threads.Count > 0)
            {
                Console.WriteLine(String.Join(" ", threads));
            }
        }
    }
}
