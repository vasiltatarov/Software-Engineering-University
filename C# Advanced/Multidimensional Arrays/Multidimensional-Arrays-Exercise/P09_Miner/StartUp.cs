using System;

namespace P09_Miner
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var minerDirections = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var minerRow = 0;
            var minerCol = 0;
            var allCoals = 0;
            var matrix = ReadMatrixData(n, ref minerRow, ref minerCol, ref allCoals);
            var collectCoals = 0;

            foreach (var direction in minerDirections)
            {
                if (direction == "up" && IsValidPosition(minerRow - 1, minerCol, matrix))
                {
                    minerRow -= 1;
                }
                if (direction == "down" && IsValidPosition(minerRow + 1, minerCol, matrix))
                {
                    minerRow += 1;
                }
                if (direction == "left" && IsValidPosition(minerRow, minerCol - 1, matrix))
                {
                    minerCol -= 1;
                }
                if (direction == "right" && IsValidPosition(minerRow, minerCol + 1, matrix))
                {
                    minerCol += 1;
                }

                if (matrix[minerRow, minerCol] == 'c')
                {
                    collectCoals++;
                    matrix[minerRow, minerCol] = '*';

                    if (allCoals == collectCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        return;
                    }
                }
                else if (matrix[minerRow, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }
            }

            Console.WriteLine($"{allCoals - collectCoals} coals left. ({minerRow}, {minerCol})");
        }

        private static bool IsValidPosition(int row, int col, char[,] matrix)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        private static char[,] ReadMatrixData(int n, ref int minerRow, ref int minerCol, ref int allCoals)
        {
            var matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = char.Parse(values[col]);

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }

                    if (matrix[row, col] == 'c')
                    {
                        allCoals++;
                    }
                }
            }

            return matrix;
        }
    }
}
