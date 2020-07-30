using System;
using System.Text;

namespace Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = Console.ReadLine();


            while (input != "Done")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "TakeOdd":
                        string newPassword = string.Empty;
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 == 1)
                            {
                                newPassword += password[i];
                            }
                        }
                        password = newPassword;
                        Console.WriteLine(password);
                        break;

                    case "Cut":
                        int index = int.Parse(command[1]);
                        int length = int.Parse(command[2]);
                        string removeSubstring = password.Substring(index, length);

                        int removeIndex = password.IndexOf(removeSubstring);
                        password = password.Remove(removeIndex, length);
                        Console.WriteLine(password);

                        break;

                    case "Substitute":

                        string substring = command[1];
                        string substitute = command[2];
                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }

                        break;
                }



                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
