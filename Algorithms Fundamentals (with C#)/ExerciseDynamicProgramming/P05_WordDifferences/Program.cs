using System;

namespace P05_WordDifferences
{
    class Program
    {
        static void Main()
        {
            var str = Console.ReadLine();
            var str1 = Console.ReadLine();

            var table = new int[str.Length + 1, str1.Length + 1];
            var count = LongestCommonSubsequence(table, str, str1);

            Console.WriteLine($"Deletions and Insertions: {count}");
        }

        private static int LongestCommonSubsequence(int[,] table, string str, string str1)
        {
            //Fill first row
            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r;
            }

            //Fill first col
            for (int c = 0; c < table.GetLength(1); c++)
            {
                table[0, c] = c;
            }

            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (str[row - 1] == str1[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1];
                    }
                    else
                    {
                        table[row, col] = Math.Min(table[row, col - 1], table[row - 1, col]) + 1;
                    }
                }
            }

            return table[str.Length, str1.Length];
        }
    }
}
