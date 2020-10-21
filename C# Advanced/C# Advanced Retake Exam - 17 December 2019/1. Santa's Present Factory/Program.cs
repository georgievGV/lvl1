using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materialsArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] magicValuesArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Dictionary<string, int> presents = new Dictionary<string, int>();

            Stack<int> materialBoxes = new Stack<int>();
            for (int i = 0; i < materialsArray.Length; i++)
            {
                if (materialsArray[i] != 0)
                {
                    materialBoxes.Push(materialsArray[i]);
                }
            }

            Queue<int> magicValues = new Queue<int>();
            for (int i = 0; i < magicValuesArray.Length; i++)
            {
                if (magicValuesArray[i] != 0)
                {
                    magicValues.Enqueue(magicValuesArray[i]);
                }
            }

            while (materialBoxes.Count > 0 && magicValues.Count > 0)
            {
                int currentBoxValue = materialBoxes.Peek();
                if (currentBoxValue == 0)
                {
                    materialBoxes.Pop();
                    continue;
                }

                int currentMagicValue = magicValues.Peek();
                if (currentMagicValue == 0)
                {
                    magicValues.Dequeue();
                    continue;
                }

                int magicLevel = currentBoxValue * currentMagicValue;
                if (magicLevel < 0)
                {
                    magicLevel = currentBoxValue + currentMagicValue;
                    materialBoxes.Pop();
                    magicValues.Dequeue();
                    materialBoxes.Push(magicLevel);
                    continue;
                }

                if(!CheckForPresent(presents, magicLevel))
                {
                    currentBoxValue += 15;
                    magicValues.Dequeue();
                    materialBoxes.Pop();
                    materialBoxes.Push(currentBoxValue);
                }
                else
                {
                    materialBoxes.Pop();
                    magicValues.Dequeue();
                }
            }

            if (presents.ContainsKey("Bicycle") && presents.ContainsKey("Teddy bear")
                || presents.ContainsKey("Doll") && presents.ContainsKey("Wooden train"))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materialBoxes.Count > 0)
            {
                Console.WriteLine($"Materials left: {String.Join(", ", materialBoxes)}");
            }

            if (magicValues.Count > 0)
            {
                Console.WriteLine($"Magic left: {String.Join(", ", magicValues)}");
            }


            presents = presents.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var present in presents)
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }
        }

        static bool CheckForPresent(Dictionary<string, int> presents, int magicLelvel)
        {
            switch (magicLelvel)
            {
                case 150:
                    if (!presents.ContainsKey("Doll"))
                    {
                        presents.Add("Doll", 0);
                    }
                    presents["Doll"]++;
                    return true;

                case 250:
                    if (!presents.ContainsKey("Wooden train"))
                    {
                        presents.Add("Wooden train", 0);
                    }
                    presents["Wooden train"]++;
                    return true;

                case 300:
                    if (!presents.ContainsKey("Teddy bear"))
                    {
                        presents.Add("Teddy bear", 0);
                    }
                    presents["Teddy bear"]++;
                    return true;

                case 400:
                    if (!presents.ContainsKey("Bicycle"))
                    {
                        presents.Add("Bicycle", 0);
                    }
                    presents["Bicycle"]++;
                    return true;
            }
            return false;
        }
    }
}
