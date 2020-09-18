using System;
using System.Linq;

namespace _05_SquarewithMaximumSum
{
    public class StartUp
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = sizes[0];
            var cols = sizes[1];
            var matrix = new int[rows, cols];

            ReadElements(matrix);

            var bestRow = 0;
            var bestCol = 0;
            var bestSum = int.MinValue;


            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                var currSum = 0;

                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currSum > bestSum)
                    {
                        bestSum = currSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine(matrix[bestRow, bestCol] + " " + matrix[bestRow, bestCol + 1]);
            Console.WriteLine(matrix[bestRow + 1, bestCol] + " " + matrix[bestRow + 1, bestCol + 1]);
            Console.WriteLine(bestSum);
        }

        private static void ReadElements(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}
