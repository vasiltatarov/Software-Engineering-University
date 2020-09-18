using System;

namespace _07.PascalTriangle
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new long[n][];
            var currentWidth = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new long[currentWidth];
                matrix[row][0] = 1;
                matrix[row][matrix[row].Length - 1] = 1;
                currentWidth++;

                if (matrix[row].Length > 2)
                {
                    for (int col = 1; col < matrix[row].Length - 1; col++)
                    {
                        var firstNum = matrix[row - 1][col];
                        var secondNum = matrix[row - 1][col - 1];
                        matrix[row][col] = firstNum + secondNum;
                    }
                }
            }

            PrintTriangle(matrix);
        }

        private static void PrintTriangle(long[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
