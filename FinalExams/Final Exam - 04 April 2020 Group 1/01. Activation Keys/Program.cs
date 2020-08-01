using System;
using System.Text;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActKey = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] command = input.Split(">>>");

                if (command[0] == "Contains")
                {
                    if (rawActKey.Contains(command[1]))
                    {
                        Console.WriteLine($"{rawActKey} contains {command[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                if (command[0] == "Flip")
                {
                    int startIndex = int.Parse(command[2]);
                    int endIndex = int.Parse(command[3]);
                    StringBuilder sb = new StringBuilder(rawActKey);

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        if (char.IsLetter(sb[i]))
                        {
                            if (command[1] == "Upper")
                            {
                                if (sb[i] >= 97 && sb[i] <= 122)
                                {
                                    char current = (char)(sb[i] - 32);
                                    sb.Replace(sb[i], current, i, 1);
                                }
                            }
                            else if (command[1] == "Lower")
                            {
                                if (sb[i] >= 65 && sb[i] <= 90)
                                {
                                    char current = (char)(sb[i] + 32);
                                    sb.Replace(sb[i], current, i, 1);
                                }
                            }
                            
                            
                        }
                    }
                    rawActKey = sb.ToString();
                    Console.WriteLine(rawActKey);
                }

                if (command[0] == "Slice")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    rawActKey = rawActKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(rawActKey);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {rawActKey}");
        }
    }
}
