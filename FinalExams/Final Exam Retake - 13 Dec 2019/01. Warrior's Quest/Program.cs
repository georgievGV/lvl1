using System;
using System.Text;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "For Azeroth")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "GladiatorStance":
                        skill = skill.ToUpper();
                        Console.WriteLine(skill);
                        break;

                    case "DefensiveStance":
                        skill = skill.ToLower();
                        Console.WriteLine(skill);
                        break;

                    case "Dispel":
                        int index = int.Parse(command[1]);
                        char letter = char.Parse(command[2]);
                        StringBuilder sb = new StringBuilder(skill);

                        if (index >= 0 && index < skill.Length)
                        {
                            sb.Replace(skill[index], letter, index, 1);
                            skill = sb.ToString();
                            Console.WriteLine("Success!");
                        }
                        else
                        {
                            Console.WriteLine("Dispel too weak.");
                        }
                        break;

                    case "Target":

                        if (command[1] == "Change")
                        {
                            string substringOne = command[2];
                            string substringTwo = command[3];

                            if (skill.Contains(substringOne))
                            {
                                skill = skill.Replace(substringOne, substringTwo);
                                Console.WriteLine(skill);
                            }

                        }
                        else if (command[1] == "Remove")
                        {
                            string substring = command[2];

                            if (skill.Contains(substring))
                            {
                                int removeIndex = skill.IndexOf(substring);
                                skill = skill.Remove(removeIndex, substring.Length);
                                Console.WriteLine(skill);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");
                        }
                        break;

                    default:
                        Console.WriteLine("Command doesn't exist!");
                        break;
                }


                input = Console.ReadLine();
            }
        }
    }
}
