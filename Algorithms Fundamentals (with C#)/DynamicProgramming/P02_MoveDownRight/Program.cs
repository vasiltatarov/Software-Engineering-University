using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_MoveDownRight
{
    class Program
    {
        private static int[,] numbers;
        private static int[,] sums;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            numbers = ReadMatrix(n, m);
            sums = new int[n, m];

            FillSumsMatrix();
            var sumsPath = FindSumsPath();

            Console.WriteLine(string.Join(" ", sumsPath));
        }

        private static Stack<string> FindSumsPath()
        {
            var sumsPath = new Stack<string>();

            var row = sums.GetLength(0) - 1;
            var col = sums.GetLength(1) - 1;

            sumsPath.Push($"[{row}, {col}]");

            while (row > 0 && col > 0)
            {
                var upperCell = sums[row - 1, col];
                var leftCell = sums[row, col - 1];

                if (upperCell > leftCell)
                {
                    row--;
                }
                else
                {
                    col--;
                }

                sumsPath.Push($"[{row}, {col}]");
            }

            while (row > 0)
            {
                row--;
                sumsPath.Push($"[{row}, {col}]");
            }


            while (col > 0)
            {
                col--;
                sumsPath.Push($"[{row}, {col}]");
            }

            return sumsPath;
        }

        private static void FillSumsMatrix()
        {
            sums[0, 0] = numbers[0, 0];

            for (int c = 1; c < numbers.GetLength(1); c++)
            {
                sums[0, c] = sums[0, c - 1] + numbers[0, c];
            }

            for (int r = 1; r < numbers.GetLength(1); r++)
            {
                sums[r, 0] = sums[r - 1, 0] + numbers[r, 0];
            }

            for (int r = 1; r < sums.GetLength(0); r++)
            {
                for (int c = 1; c < sums.GetLength(1); c++)
                {
                    var upperCell = sums[r - 1, c];
                    var leftCell = sums[r, c - 1];
                    sums[r, c] = Math.Max(upperCell, leftCell) + numbers[r, c];
                }
            }
        }

        private static int[,] ReadMatrix(int n, int m)
        {
            var matrix = new int[n, m];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var data = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = data[c];
                }
            }

            return matrix;
        }
    }
}
