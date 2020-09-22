using System;
using System.Linq;

namespace P02_2X2SquaresInMatrix
{
    public class StartUp
    {
        static void Main()
        {
            var sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[sizes[0], sizes[1]];
            ReadElements(matrix);
            var allSquares = FindSquaresOfEqualChars(matrix);

            Console.WriteLine(allSquares);
        }

        private static int FindSquaresOfEqualChars(int[,] matrix)
        {

            var result = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var firstChar = matrix[row, col];
                    var secondChar = matrix[row + 1, col];
                    var thirdChar = matrix[row, col + 1];
                    var fourthChar = matrix[row + 1, col + 1];

                    if (secondChar == firstChar && thirdChar == firstChar && fourthChar == firstChar)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private static void ReadElements(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var elements = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = char.Parse(elements[col]);
                }
            }
        }
    }
}
