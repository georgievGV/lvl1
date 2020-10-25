using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int foodQuantity = 0;
            int snakeRow = -1;
            int snakeCol = -1;
            int firstBurrowRow = -1;
            int firstBurrowCol = -1;
            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (rowData[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (rowData[col] == 'B')
                    {
                        if (firstBurrowRow == -1)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }
                }
            }

            string command = Console.ReadLine();
            bool isOutsideTerritory = false;
            bool isFed = false;
            int[] snakePosition = new int[2];

            while (true)
            {
                matrix[snakeRow, snakeCol] = '.';
                switch (command)
                {
                    case "up":
                        snakeRow--;
                        if (snakeRow == -1)
                        {
                            isOutsideTerritory = true;
                            break;
                        }

                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                        }
                        else if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            snakePosition = GetSnakePosition(matrix, snakeRow, snakeCol, firstBurrowRow, firstBurrowCol, secondBurrowRow, secondBurrowCol);
                            snakeRow = snakePosition[0];
                            snakeCol = snakePosition[1];
                        }
                        break;

                    case "right":
                        snakeCol++;
                        if (snakeCol == matrix.GetLength(1))
                        {
                            isOutsideTerritory = true;
                            break;
                        }

                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                        }
                        else if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            snakePosition = GetSnakePosition(matrix, snakeRow, snakeCol, firstBurrowRow, firstBurrowCol, secondBurrowRow, secondBurrowCol);
                            snakeRow = snakePosition[0];
                            snakeCol = snakePosition[1];
                        }

                        break;

                    case "down":
                        snakeRow++;
                        if (snakeRow == matrix.GetLength(0))
                        {
                            isOutsideTerritory = true;
                            break;
                        }

                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                        }
                        else if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            snakePosition = GetSnakePosition(matrix, snakeRow, snakeCol, firstBurrowRow, firstBurrowCol, secondBurrowRow, secondBurrowCol);
                            snakeRow = snakePosition[0];
                            snakeCol = snakePosition[1];
                        }
                        break;

                    case "left":
                        snakeCol--;
                        if (snakeCol == -1)
                        {
                            isOutsideTerritory = true;
                            break;
                        }

                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                        }
                        else if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            snakePosition = GetSnakePosition(matrix, snakeRow, snakeCol, firstBurrowRow, firstBurrowCol, secondBurrowRow, secondBurrowCol);
                            snakeRow = snakePosition[0];
                            snakeCol = snakePosition[1];
                        }
                        break;
                }

                if (isOutsideTerritory)
                {
                    break;
                }
                else
                {
                    matrix[snakeRow, snakeCol] = 'S';
                }

                if (foodQuantity == 10)
                {
                    isFed = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (isOutsideTerritory)
            {
                Console.WriteLine("Game over!");
            }
            else if (foodQuantity == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static int[] GetSnakePosition(char[,] matrix, int snakeRow, int snakeCol, int firstBurrowRow, int firstBurrowCol, int secondBurrowRow, int secondBurrowCol)
        {
            matrix[snakeRow, snakeCol] = '.';
            if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
            {
                snakeRow = secondBurrowRow;
                snakeCol = secondBurrowCol;
            }
            else if (snakeRow == secondBurrowRow && snakeCol == secondBurrowCol)
            {
                snakeRow = firstBurrowRow;
                snakeCol = firstBurrowCol;
            }

            return new int[] {snakeRow, snakeCol};
        }
    }
}
