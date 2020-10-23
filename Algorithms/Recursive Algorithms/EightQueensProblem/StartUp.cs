using System;

namespace EightQueensProblem
{
    public class Program
    {
        private const char QUEEN_SYMBOL = 'Q';
        private const char EMPTY_SYMBOL = '-';

        static void Main()
        {
            var queens = int.Parse(Console.ReadLine());
            var table = new int[queens, queens];

            
            var times = GetQueens(table, 0);

            Console.WriteLine($"{times} - Times!");
        }

        private static int GetQueens(int[,] table, int row)
        {
            if (row == table.GetLength(0))
            {
                PrintCurrentQueens(table);
                Console.WriteLine();
                return 1;
            }

            var counter = 0;

            for (int col = 0; col < table.GetLength(1); col++)
            {
                if (IsSafeMovement(table, row, col))
                {
                    table[row, col] = 1;
                    counter += GetQueens(table, row + 1);
                    table[row, col] = 0;
                }
            }

            return counter;
        }

        private static bool IsSafeMovement(int[,] table, int row, int col)
        {
            for (int i = 1; i < table.GetLength(0); i++)
            {
                if (row - i >= 0 && row - i < table.GetLength(0) && table[row - i, col] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && col - i < table.GetLength(1) && table[row, col - i] == 1)
                {
                    return false;
                }
                if (row + i >= 0 && row + i < table.GetLength(0) && table[row + i, col] == 1)
                {
                    return false;
                }
                if (col + i >= 0 && col + i < table.GetLength(1) && table[row, col + i] == 1)
                {
                    return false;
                }
                if (row - i >= 0 && col - i >= 0 && row - i < table.GetLength(0) && col - i < table.GetLength(1) && table[row - i, col - i] == 1)
                {
                    return false;
                }
                if (row - i >= 0 && col + i >= 0 && row - i < table.GetLength(0) && col + i < table.GetLength(1) && table[row - i, col + i] == 1)
                {
                    return false;
                }
                if (row + i >= 0 && col - i >= 0 && row + i < table.GetLength(0) && col - i < table.GetLength(1) && table[row + i, col - i] == 1)
                {
                    return false;
                }
                if (row + i >= 0 && col + i >= 0 && row + i < table.GetLength(0) && col + i < table.GetLength(1) && table[row + i, col + i] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintCurrentQueens(int[,] table)
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (table[row, col] == 1)
                    {
                        Console.Write(QUEEN_SYMBOL + " ");
                    }
                    else
                    {
                        Console.Write(EMPTY_SYMBOL + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
