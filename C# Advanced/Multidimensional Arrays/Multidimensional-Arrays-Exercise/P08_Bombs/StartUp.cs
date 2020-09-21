using System;
using System.Linq;

namespace P08_Bombs
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix(n);
            var coordinates = Console.ReadLine().Split();

            for (int i = 0; i < coordinates.Length; i++)
            {
                var args = coordinates[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var row = args[0];
                var col = args[1];

                if (matrix[row, col] <= 0)
                {
                    continue;
                }

                var bombValue = matrix[row, col];
                matrix[row, col] = 0;
                BombExplode(matrix, row, col, bombValue);
            }

            var aliveCells = 0;
            var sumOfCells = 0;
            FindAliveCells(matrix, ref aliveCells, ref sumOfCells);

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");
            PrintMatrix(matrix);
        }

        private static void FindAliveCells(int[,] matrix, ref int aliveCells, ref int sumOfCells)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sumOfCells += matrix[row, col];
                    }
                }
            }
        }

        private static void BombExplode(int[,] matrix, int row, int col, int bombValue)
        {
            if (IsValidIndex(row - 1, col - 1, matrix) && ValueIsBiggerThanZero(row - 1, col - 1, matrix))
            {
                matrix[row - 1, col - 1] -= bombValue;
            }
            if (IsValidIndex(row - 1, col, matrix) && ValueIsBiggerThanZero(row - 1, col, matrix))
            {
                matrix[row - 1, col] -= bombValue;
            }
            if (IsValidIndex(row - 1, col + 1, matrix) && ValueIsBiggerThanZero(row - 1, col + 1, matrix))
            {
                matrix[row - 1, col + 1] -= bombValue;
            }
            if (IsValidIndex(row, col - 1, matrix) && ValueIsBiggerThanZero(row, col - 1, matrix))
            {
                matrix[row, col - 1] -= bombValue;
            }
            if (IsValidIndex(row, col + 1, matrix) && ValueIsBiggerThanZero(row, col + 1, matrix))
            {
                matrix[row, col + 1] -= bombValue;
            }
            if (IsValidIndex(row + 1, col - 1, matrix) && ValueIsBiggerThanZero(row + 1, col - 1, matrix))
            {
                matrix[row + 1, col - 1] -= bombValue;
            }
            if (IsValidIndex(row + 1, col, matrix) && ValueIsBiggerThanZero(row + 1, col, matrix))
            {
                matrix[row + 1, col] -= bombValue;
            }
            if (IsValidIndex(row + 1, col + 1, matrix) && ValueIsBiggerThanZero(row + 1, col + 1, matrix))
            {
                matrix[row + 1, col + 1] -= bombValue;
            }
        }

        private static bool ValueIsBiggerThanZero(int row, int col, int[,] matrix)
            => matrix[row, col] > 0;

        private static bool IsValidIndex(int row, int col, int[,] matrix)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

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

        private static int[,] ReadMatrix(int n)
        {
            var matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            return matrix;
        }
    }
}
