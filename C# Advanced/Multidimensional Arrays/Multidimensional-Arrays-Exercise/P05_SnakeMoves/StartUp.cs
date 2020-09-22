using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_SnakeMoves
{
    public class StartUp
    {
        static void Main()
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var snake = Console.ReadLine();
            var queue = new Queue<char>(snake);
            var matrix = new char[dimensions[0], dimensions[1]];
            ReadData(queue, matrix);
            PrintMatrix(matrix);
        }

        private static void ReadData(Queue<char> queue, char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        var currValue = queue.Dequeue();
                        matrix[row, col] = currValue;
                        queue.Enqueue(currValue);
                    }
                    else
                    {
                        var currValue = queue.Dequeue();
                        matrix[row, matrix.GetLength(1) - 1 - col] = currValue;
                        queue.Enqueue(currValue);
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

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
