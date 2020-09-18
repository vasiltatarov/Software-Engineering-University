using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix(n);
            var diagonalSum = FindDiagonalSum(matrix);
            Console.WriteLine(diagonalSum);
        }

        private static int FindDiagonalSum(int[,] matrix)
        {
            var diagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                diagonalSum += matrix[row, row];
            }

            return diagonalSum;
        }

        private static int[,] ReadMatrix(int n)
        {
            var matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            return matrix;
        }
    }
}
