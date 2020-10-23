using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;
            int pollinateFlowers = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (rowData[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            bool isLost = false;

            while (command != "End")
            {
                matrix[beeRow, beeCol] = '.';
                switch (command)
                {
                    case "up":
                        beeRow--;

                        if (beeRow == -1)
                        {
                            isLost = true;
                            break;
                        }

                        if (matrix[beeRow,beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeRow--;

                            if (beeRow == -1)
                            {
                                isLost = true;
                                break;
                            }
                        }

                        if (matrix[beeRow, beeCol] == 'f')
                        {
                            pollinateFlowers++;
                        }
                        break;

                    case "right":
                        beeCol++;

                        if (beeCol == matrix.GetLength(1))
                        {
                            isLost = true;
                            break;
                        }

                        if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeCol++;

                            if (beeCol == matrix.GetLength(1))
                            {
                                isLost = true;
                                break;
                            }

                        }

                        if (matrix[beeRow, beeCol] == 'f')
                        {
                            pollinateFlowers++;
                        }
                        break;

                    case "down":
                        beeRow++;

                        if (beeRow == matrix.GetLength(0))
                        {
                            isLost = true;
                            break;
                        }

                        if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeRow++;

                            if (beeCol == matrix.GetLength(1))
                            {
                                isLost = true;
                                break;
                            }
                        }

                        if (matrix[beeRow, beeCol] == 'f')
                        {
                            pollinateFlowers++;
                        }
                        break;

                    case "left":
                        beeCol--;

                        if (beeCol == -1)
                        {
                            isLost = true;
                            break;
                        }

                        if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeCol--;

                            if (beeCol == -1)
                            {
                                isLost = true;
                                break;
                            }
                        }

                        if (matrix[beeRow, beeCol] == 'f')
                        {
                            pollinateFlowers++;
                        }
                        break;
                }

                if (isLost)
                {
                    break;
                }
                else
                {
                    matrix[beeRow, beeCol] = 'B';
                }

                command = Console.ReadLine();
            }

            if (isLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (pollinateFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinateFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinateFlowers} flowers!");
            }
        }
    }
}
