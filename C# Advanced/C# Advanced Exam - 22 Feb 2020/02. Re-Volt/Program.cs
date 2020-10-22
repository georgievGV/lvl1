using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandLines = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (rowData[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool isFinish = false;
            for (int i = 0; i < commandLines; i++)
            {
                string command = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';

                switch (command)
                {
                    case "up":
                        playerRow--;

                        if (playerRow == -1)
                        {
                            playerRow = matrix.GetLength(0) - 1;
                        }

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            if (playerRow == 0)
                            {
                                playerRow = matrix.GetLength(0);
                            }
                            playerRow--;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            if (playerRow == matrix.GetLength(0) -1)
                            {
                                playerRow = -1;
                            }
                            playerRow++;
                        }

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            isFinish = true;
                        }
                        break;

                    case "right":
                        playerCol++;

                        if (playerCol == matrix.GetLength(1))
                        {
                            playerCol = 0;
                        }

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            if (playerCol == matrix.GetLength(1) - 1)
                            {
                                playerCol = -1;
                            }
                            playerCol++;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            if (playerCol == 0)
                            {
                                playerCol = matrix.GetLength(1);
                            }
                            playerCol--;
                        }

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            isFinish = true;
                        }
                        break;

                    case "down":
                        playerRow++;

                        if (playerRow == matrix.GetLength(0))
                        {
                            playerRow = 0;
                        }

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            if (playerRow == matrix.GetLength(0) - 1)
                            {
                                playerRow = -1;
                            }
                            playerRow++;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            if (playerRow == 0)
                            {
                                playerRow = matrix.GetLength(0);
                            }
                            playerRow--;
                        }

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            isFinish = true;
                        }
                        break;

                    case "left":
                        playerCol--;

                        if (playerCol == -1)
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            if (playerCol == 0)
                            {
                                playerCol = matrix.GetLength(1);
                            }
                            playerCol--;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            if (playerCol == matrix.GetLength(1) -1)
                            {
                                playerCol = -1;
                            }
                            playerCol++;
                        }

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            isFinish = true;
                        }
                        break;
                }
                matrix[playerRow, playerCol] = 'f';

                if (isFinish)
                {
                    break;
                }
            }

            if (isFinish)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
