using System;

namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int firstPlayerRow = -1;
            int firstPlayerCol = -1;
            int secondPlayerRow = -1;
            int secondPlayerCol = -1;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < rowData.Length; col++)
                {
                    field[row, col] = rowData[col];

                    if (rowData[col] == 'f')
                    {
                        firstPlayerCol = col;
                        firstPlayerRow = row;
                    }
                    else if (rowData[col] == 's')
                    {
                        secondPlayerCol = col;
                        secondPlayerRow = row;
                    }
                }
            }

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool isDead = false;

            while (!isDead)
            {

                for (int i = 0; i < commands.Length; i++)
                {
                    string currCommand = commands[i];
                    int playerRow = -1;
                    int playerCol = -1;
                    char player = '\0';

                    if (i == 0)
                    {
                        playerRow = firstPlayerRow;
                        playerCol = firstPlayerCol;
                        player = 'f';
                    }
                    else
                    {
                        playerRow = secondPlayerRow;
                        playerCol = secondPlayerCol;
                        player = 's';
                    }

                    switch (currCommand)
                    {
                        case "up":
                            playerRow--;
                            if (playerRow == -1)
                            {
                                playerRow = field.GetLength(0) - 1;
                            }
                            break;

                        case "right":
                            playerCol++;
                            if (playerCol == field.GetLength(1))
                            {
                                playerCol = 0;
                            }
                            break;

                        case "down":
                            playerRow++;
                            if (playerRow == field.GetLength(0))
                            {
                                playerRow = 0;
                            }
                            break;

                        case "left":
                            playerCol--;
                            if (playerCol == -1)
                            {
                                playerCol = field.GetLength(1) - 1;
                            }
                            break;
                    }

                    char enemy = '\0';
                    if (player == 's')
                    {
                        enemy = 'f';
                    }
                    else if (player == 'f')
                    {
                        enemy = 's';
                    }

                    if (field[playerRow, playerCol] == enemy)
                    {
                        field[playerRow, playerCol] = 'x';
                        isDead = true;
                        break;
                    }
                    else if (field[playerRow, playerCol] == '*')
                    {
                        field[playerRow, playerCol] = player;
                    }

                    if (i == 0)
                    {
                        firstPlayerRow = playerRow;
                        firstPlayerCol = playerCol;
                    }
                    else
                    {
                        secondPlayerRow = playerRow;
                        secondPlayerCol = playerCol;
                    }

                }

                if (!isDead)
                {
                    commands = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}