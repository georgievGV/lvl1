using System;
using System.Linq;

namespace _2._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presents = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] neighborhood = new char[n, n];
            int santaRow = -1;
            int santaCol = -1;
            int niceKids = 0;

            for (int row = 0; row < neighborhood.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < neighborhood.GetLength(1); col++)
                {
                    neighborhood[row, col] = rowData[col];
                    if (rowData[col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }
                    else if (rowData[col] == 'V')
                    {
                        niceKids++;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "Christmas morning" && presents > 0)
            {
                neighborhood[santaRow, santaCol] = '-';
                switch (command)
                {
                    case "up":
                        santaRow--;
                        presents = CheckTheHouse(presents, neighborhood, santaRow, santaCol);
                        break;

                    case "right":
                        santaCol++;
                        presents = CheckTheHouse(presents, neighborhood, santaRow, santaCol);
                        break;

                    case "down":
                        santaRow++;
                        presents = CheckTheHouse(presents, neighborhood, santaRow, santaCol);
                        break;

                    case "left":
                        santaCol--;
                        presents = CheckTheHouse(presents, neighborhood, santaRow, santaCol);
                        break;
                }
                neighborhood[santaRow, santaCol] = 'S';


                command = Console.ReadLine();
            }

            if (presents == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            else if (presents < 0)
            {
                Console.WriteLine("presents become a negative number!");
            }

            int niceKidsLeft = 0;
            for (int row = 0; row < neighborhood.GetLength(0); row++)
            {
                for (int col = 0; col < neighborhood.GetLength(1); col++)
                {
                    Console.Write(neighborhood[row, col] + " ");
                    if (neighborhood[row, col] == 'V')
                    {
                        niceKidsLeft++;
                    }
                }
                Console.WriteLine();
            }

            if (niceKidsLeft == 0)
            {
                Console.WriteLine($"Good job, Santa! {niceKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsLeft} nice kid/s.");
            }
        }

        private static int  CheckTheHouse(int presents, char[,] neighborhood, int santaRow, int santaCol)
        {
            if (neighborhood[santaRow, santaCol] == 'V')
            {
                presents--;
            }
            else if (neighborhood[santaRow, santaCol] == 'C')
            {
                if (santaRow > 0)
                {
                    if (neighborhood[santaRow - 1, santaCol] == 'X'
                       || neighborhood[santaRow - 1, santaCol] == 'V')
                    {
                        neighborhood[santaRow - 1, santaCol] = '-';
                        presents--;
                    }
                }

                if (santaCol < neighborhood.GetLength(1) - 1)
                {
                    if (neighborhood[santaRow, santaCol + 1] == 'X'
                       || neighborhood[santaRow, santaCol + 1] == 'V')
                    {
                        neighborhood[santaRow, santaCol + 1] = '-';
                        presents--;
                    }
                }

                if (santaRow < neighborhood.GetLength(0) - 1)
                {
                    if (neighborhood[santaRow + 1, santaCol] == 'X'
                       || neighborhood[santaRow + 1, santaCol] == 'V')
                    {
                        neighborhood[santaRow + 1, santaCol] = '-';
                        presents--;
                    }
                }

                if (santaCol > 0)
                {
                    if (neighborhood[santaRow, santaCol - 1] == 'X'
                       || neighborhood[santaRow, santaCol - 1] == 'V')
                    {
                        neighborhood[santaRow, santaCol - 1] = '-';
                        presents--;
                    }
                }
            }

            return presents;
        }
    }
}
