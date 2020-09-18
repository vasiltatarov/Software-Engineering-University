using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    public class StartUp
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var matrix = ReadElements(rows);

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var sign = args[0];
                var row = int.Parse(args[1]);
                var col = int.Parse(args[2]);
                var value = int.Parse(args[3]);

                if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (sign == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (sign == "Subtract")
                {
                    matrix[row][col] -= value;
                }
            }

            PrintElements(matrix);
        }

        private static void PrintElements(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static int[][] ReadElements(int rows)
        {
            var matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = new int[elements.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = elements[col];
                }
            }

            return matrix;
        }
    }
}
