using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] males = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] females = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> maleStack = new Stack<int>(males);
            List<int> maleList = new List<int>(maleStack);
            Queue<int> femaleQueue = new Queue<int>(females);
            int matches = 0;

            while (maleList.Count > 0 && femaleQueue.Count > 0)
            {
                int currFemale = femaleQueue.Peek();
                int currMale = maleList[0];


                if (currFemale <= 0 || currMale <= 0)
                {
                    if (currMale <= 0)
                    {
                        maleList.RemoveAt(0);
                    }
                    else if (currFemale <= 0)
                    {
                        femaleQueue.Dequeue();
                    }

                }
                else
                {
                    if (currFemale % 25 == 0 || currMale % 25 == 0)
                    {
                        if (currFemale % 25 == 0)
                        {
                            femaleQueue.Dequeue();
                            if (femaleQueue.Count > 0)
                            {
                                femaleQueue.Dequeue();
                            }

                        }

                        if (currMale % 25 == 0)
                        {
                            maleList.RemoveAt(0);
                            if (maleList.Count > 0)
                            {
                                maleList.RemoveAt(0);
                            }
                        }

                        continue;
                    }

                    if (maleList.Count == 0 || femaleQueue.Count == 0)
                    {
                        break;
                    }

                    if (currFemale == currMale)
                    {
                        femaleQueue.Dequeue();
                        maleList.RemoveAt(0);
                        matches++;
                    }
                    else
                    {
                        femaleQueue.Dequeue();
                        maleList[0] -= 2;
                    }
                }
            }

            Console.WriteLine($"Matches: {matches}");
            if (maleList.Count > 0)
            {
                Console.WriteLine($"Males left: {String.Join(", ", maleList)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (femaleQueue.Count > 0)
            {
                Console.WriteLine($"Females left: {String.Join(", ", femaleQueue)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
