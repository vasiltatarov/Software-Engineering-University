using System;
using System.Linq;

namespace P03_MaximalSum
{
    public class StartUp
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[sizes[0], sizes[1]];
            ReadElements(matrix);
            var maxSum = 0;
            var startRow = 0;
            var startCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[startRow, startCol]} {matrix[startRow, startCol + 1]} {matrix[startRow, startCol + 2]}");
            Console.WriteLine($"{matrix[startRow + 1, startCol]} {matrix[startRow + 1, startCol + 1]} {matrix[startRow + 1, startCol + 2]}");
            Console.WriteLine($"{matrix[startRow + 2, startCol]} {matrix[startRow + 2, startCol + 1]} {matrix[startRow + 2, startCol + 2]}");
        }

        private static void ReadElements(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}
