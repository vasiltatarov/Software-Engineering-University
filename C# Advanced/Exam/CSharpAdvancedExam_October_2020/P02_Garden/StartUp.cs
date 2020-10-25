using System;
using System.Linq;

namespace P02_Exam
{
    public class StartUp
    {
        static void Main()
        {
            var n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[n[0], n[1]];

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Bloom Bloom Plow")
                {
                    break;
                }

                var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var row = args[0];
                var col = args[1];

                if (!IsValidMove(matrix, row, col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        if (rows == row)
                        {
                            matrix[rows, cols]++;
                        }
                        else if (cols == col)
                        {
                            matrix[rows, cols]++;
                        }
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static bool IsValidMove(int[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
