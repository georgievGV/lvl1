using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int hp = int.Parse(info[1]);
                if (hp > 100)
                {
                    hp = 100;
                }
                int mp = int.Parse(info[2]);
                if (mp > 200)
                {
                    mp = 200;
                }
                Hero currentHero = new Hero(name, hp, mp);

                if (!heroes.ContainsKey(name))
                {
                    heroes.Add(name, currentHero);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split(" - ");

                switch (command[0])
                {
                    case "CastSpell":

                        if (heroes[command[1]].Mp >= int.Parse(command[2]))
                        {
                            heroes[command[1]].Mp -= int.Parse(command[2]);
                            Console.WriteLine($"{command[1]} has successfully " +
                                $"cast {command[3]} and now has {heroes[command[1]].Mp} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{command[1]} does not have enough MP to cast {command[3]}!");
                        }
                        break;

                    case "TakeDamage":

                        if (heroes[command[1]].Hp > int.Parse(command[2]))
                        {
                            heroes[command[1]].Hp -= int.Parse(command[2]);
                            Console.WriteLine($"{command[1]} was hit for {command[2]} HP by " +
                                $"{command[3]} and now has {heroes[command[1]].Hp} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{command[1]} has been killed by {command[3]}!");
                            heroes[command[1]].Hp = 0;
                        }
                        break;

                    case "Recharge":

                        int originMP = heroes[command[1]].Mp;
                        int mpRegarged = 0;
                        if (heroes[command[1]].Mp + int.Parse(command[2]) > 200)
                        {
                            heroes[command[1]].Mp = 200;
                            mpRegarged = 200 - originMP;
                        }
                        else
                        {
                            heroes[command[1]].Mp += int.Parse(command[2]);
                            mpRegarged = int.Parse(command[2]);
                        }

                        Console.WriteLine($"{command[1]} recharged for {mpRegarged} MP!");
                        break;

                    case "Heal":

                        int originHP = heroes[command[1]].Hp;
                        int hpHealed = 0;
                        if (heroes[command[1]].Hp + int.Parse(command[2]) > 100)
                        {
                            heroes[command[1]].Hp = 100;
                            hpHealed = 100 - originHP;
                        }
                        else
                        {
                            heroes[command[1]].Hp += int.Parse(command[2]);
                            hpHealed = int.Parse(command[2]);
                        }
                        Console.WriteLine($"{command[1]} healed for {hpHealed} HP!");
                        break;
                }

                input = Console.ReadLine();
            }

            Dictionary<string, Hero> finalList =  heroes.Where(x=>x.Value.Hp > 0)
                .OrderByDescending(x=>x.Value.Hp).ThenBy(x=>x.Key)
                .ToDictionary(x=>x.Key,x=>x.Value);

            foreach (var items in finalList)
            {
                Console.WriteLine($"{items.Key}");
                Console.WriteLine($"HP:  {items.Value.Hp}");
                Console.WriteLine($"MP:  {items.Value.Mp}");
            }
        }
    }

    class Hero
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }

        public Hero(string name, int hp, int mp)
        {
            Name = name;
            Hp = hp;
            Mp = mp;
        }
    }
}
