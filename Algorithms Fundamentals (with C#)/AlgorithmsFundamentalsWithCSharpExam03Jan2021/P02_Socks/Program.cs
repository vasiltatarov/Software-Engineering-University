using System;
using System.Linq;

namespace P02_Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rightSocks = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var table = new int[leftSocks.Length + 1, rightSocks.Length + 1];

            var lcs = Lcs(table, leftSocks, rightSocks);

            Console.WriteLine(lcs);
        }

        private static int Lcs(int[,] table, int[] leftSocks, int[] rightSocks)
        {
            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (leftSocks[row - 1] == rightSocks[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        table[row, col] = Math.Max(table[row - 1, col], table[row, col - 1]);
                    }
                }
            }

            return table[leftSocks.Length, rightSocks.Length];
        }
    }
}
