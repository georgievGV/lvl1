using System;
using System.Linq;
using System.Text;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMsg = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] command = input.Split(":|:");

                switch (command[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(command[1]);
                        concealedMsg = concealedMsg.Insert(index, " ");
                        break;

                    case "Reverse":
                        string substring = command[1];
                        if (concealedMsg.Contains(substring))
                        {
                            int removeIndex = concealedMsg.IndexOf(substring);
                            concealedMsg = concealedMsg.Remove(removeIndex, substring.Length);
                            char[] temp = substring.ToCharArray();
                            Array.Reverse(temp);
                            substring = new string(temp);
                            concealedMsg = concealedMsg.Insert(concealedMsg.Length, substring);
                        }
                        else
                        {
                            Console.WriteLine("error");
                            input = Console.ReadLine();
                            continue;
                        }
                        break;

                    case "ChangeAll":
                        concealedMsg = concealedMsg.Replace(command[1], command[2]);
                        break;
                }

                Console.WriteLine(concealedMsg);
                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {concealedMsg}");
        }
    }
}
