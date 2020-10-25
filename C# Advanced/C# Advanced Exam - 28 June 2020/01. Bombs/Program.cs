using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effectsArray = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] casingsArray = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> bombEffects = new Queue<int>(effectsArray);
            Stack<int> bombCasings = new Stack<int>(casingsArray);
            int DaturaBombs = 0;
            int CherryBombs = 0;
            int SmokeDecoyBombs = 0;
            bool isfilledBombPouch = false;

            while (bombCasings.Count > 0 && bombEffects.Count > 0)
            {
                int currEffect = bombEffects.Peek();
                int currCasing = bombCasings.Peek();
                int sum = currCasing + currEffect;

                if (sum == 40 || sum == 60 || sum == 120)
                {
                    switch (sum)
                    {
                        case 40:
                            DaturaBombs++;
                            break;

                        case 60:
                            CherryBombs++;
                            break;

                        case 120:
                            SmokeDecoyBombs++;
                            break;
                    }

                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    currCasing -= 5;
                    bombCasings.Pop();
                    bombCasings.Push(currCasing);
                }

                if (DaturaBombs > 2 && CherryBombs > 2 && SmokeDecoyBombs > 2)
                {
                    isfilledBombPouch = true;
                    break;
                }
            }

            if (isfilledBombPouch)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");

            }

            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {CherryBombs}");
            Console.WriteLine($"Datura Bombs: {DaturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {SmokeDecoyBombs}");
        }
    }
}
