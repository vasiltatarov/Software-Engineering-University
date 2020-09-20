using System;

namespace SpiralMatrix
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            var row = 0;
            var col = 0;
            var direction = "right";

            for (int i = 1; i <= n * n; i++)
            {
                matrix[row, col] = i;

                if (direction == "right")
                {
                    col++;

                    if (col == n || matrix[row, col] != 0)
                    {
                        col--;
                        row++;
                        direction = "down";
                    }
                }
                else if (direction == "down")
                {
                    row++;

                    if (row == n || matrix[row, col] != 0)
                    {
                        row--;
                        col--;
                        direction = "left";
                    }
                }
                else if (direction == "left")
                {
                    col--;

                    if (col == -1 || matrix[row, col] != 0)
                    {
                        col++;
                        row--;
                        direction = "up";
                    }
                }
                else if (direction == "up")
                {
                    row--;

                    if (row == -1 || matrix[row, col] != 0)
                    {
                        row++;
                        col++;
                        direction = "right";
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
