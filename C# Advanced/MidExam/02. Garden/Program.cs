using System;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = sizes[0];
            int m = sizes[1];
            int[,] garden = new int[n, m];

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }

            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                int[] flowerCoordinates = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int flowerRow = flowerCoordinates[0];
                int flowerCol = flowerCoordinates[1];

                if (flowerRow < 0 || flowerRow > garden.GetLength(0) - 1
                    || flowerCol < 0 || flowerCol > garden.GetLength(1) - 1)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int row = flowerRow; row <= flowerRow; row++)
                    {
                        for (int col = 0; col < garden.GetLength(1); col++)
                        {
                            garden[row, col] += 1;
                        }
                    }

                    for (int col = flowerCol; col <= flowerCol; col++)
                    {
                        for (int row = 0; row < garden.GetLength(0); row++)
                        {
                            if (row != flowerRow)
                            {
                                garden[row, col] += 1;
                            }
                        }
                    }
                }


                command = Console.ReadLine();
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
