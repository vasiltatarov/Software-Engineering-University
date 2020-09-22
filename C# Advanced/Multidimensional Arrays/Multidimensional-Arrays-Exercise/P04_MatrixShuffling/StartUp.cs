using System;
using System.Linq;

namespace P04_MatrixShuffling
{
    public class StartUp
    {
        static void Main()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new string[dimensions[0], dimensions[1]];
            ReadData(matrix);

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var args = command.Split();

                if (args[0] == "swap" && args.Length == 5)
                {
                    var row1 = int.Parse(args[1]);
                    var col1 = int.Parse(args[2]);
                    var row2 = int.Parse(args[3]);
                    var col2 = int.Parse(args[4]);

                    if (ValidateCoordinates(row1, col1, row2, col2, matrix))
                    {
                        var temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
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

        private static bool ValidateCoordinates(int row1, int col1, int row2, int col2, string[,] matrix)
            => row1 >= 0 && row1 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1)
            && row2 >= 0 && row2 < matrix.GetLength(0) && col2 >= 0 && col2 < matrix.GetLength(1); 

        private static void ReadData(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }
        }
    }
}
