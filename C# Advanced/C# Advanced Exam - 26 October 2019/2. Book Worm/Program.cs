using System;
using System.Text;

namespace _2._Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder initial = new StringBuilder(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (rowData[col] == 'p' || rowData[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "up":
                        playerRow--;
                        if (playerRow == -1)
                        {
                            playerRow = 0;
                            Punish(initial);
                        }
                        else
                        {
                            CheckForLetters(matrix, playerRow, playerCol, initial);
                            matrix[playerRow, playerCol] = 'P';
                            matrix[playerRow + 1, playerCol] = '-';
                        }
                        break;

                    case "right":
                        playerCol++;
                        if (playerCol == matrix.GetLength(1))
                        {
                            playerCol = matrix.GetLength(1) - 1;
                            Punish(initial);
                        }
                        else
                        {
                            CheckForLetters(matrix, playerRow, playerCol, initial);
                            matrix[playerRow, playerCol] = 'P';
                            matrix[playerRow, playerCol - 1] = '-';
                        }
                        break;

                    case "down":
                        playerRow++;
                        if (playerRow == matrix.GetLength(0))
                        {
                            playerRow = matrix.GetLength(0) - 1;
                            Punish(initial);
                        }
                        else
                        {
                            CheckForLetters(matrix, playerRow, playerCol, initial);
                            matrix[playerRow, playerCol] = 'P';
                            matrix[playerRow - 1, playerCol] = '-';
                        }
                        break;

                    case "left":
                        playerCol--;
                        if (playerCol == -1)
                        {
                            playerCol = 0;
                            Punish(initial);
                        }
                        else
                        {
                            CheckForLetters(matrix, playerRow, playerCol, initial);
                            matrix[playerRow, playerCol] = 'P';
                            matrix[playerRow, playerCol + 1] = '-';
                        }
                        break;
                }

                

                command = Console.ReadLine();
            }

            Console.WriteLine(initial.ToString());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void CheckForLetters(char[,] matrix, int playerRow, int playerCol, StringBuilder initial)
        {
            if (matrix[playerRow, playerCol] != '-')
            {
                initial.Append(matrix[playerRow, playerCol]);
                matrix[playerRow, playerCol] = '-';
            }
        }

        public static void Punish(StringBuilder initial)
        {
            if (initial.Length > 0)
            {
                initial.Remove(initial.Length - 1, 1);
            }
        }
    }
}
