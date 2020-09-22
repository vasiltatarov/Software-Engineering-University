using System;
using System.Linq;

namespace MultidimensionalArraysExercise
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = ReadValues(n);
            var primaryDiagonal = FindPrimaryDiagonal(matrix);
            var secondaryDiagonal = FindSecondaryDiagonal(matrix);
            var difference = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(difference);
        }

        private static int FindSecondaryDiagonal(int[,] matrix)
        {
            var diagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                diagonal += matrix[row, matrix.GetLength(1) - 1 - row];
            }

            return diagonal;
        }

        private static int FindPrimaryDiagonal(int[,] matrix)
        {
            var diagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                diagonal += matrix[row, row];
            }

            return diagonal;
        }

        private static int[,] ReadValues(int n)
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
