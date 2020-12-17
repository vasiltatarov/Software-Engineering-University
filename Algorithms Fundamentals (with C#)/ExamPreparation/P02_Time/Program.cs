using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Time
{
    class Program
    {
        static void Main()
        {
            var firstTimeline = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondTimeline = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var table = new int[firstTimeline.Length + 1, secondTimeline.Length + 1];

            var lcs = LongestCommonSubsequence(table, firstTimeline, secondTimeline);

            var subsequence = new Stack<int>();
            GetSubsequence(table, firstTimeline, secondTimeline, subsequence);

            Console.WriteLine(string.Join(" ", subsequence));
            Console.WriteLine(lcs);
        }

        private static void GetSubsequence(int[,] table, int[] firstTimeline, int[] secondTimeline, Stack<int> result)
        {
            var row = firstTimeline.Length;
            var col = secondTimeline.Length;

            while (row > 0 && col > 0)
            {
                if (firstTimeline[row - 1] == secondTimeline[col - 1] &&
                    table[row, col] == table[row - 1, col - 1] + 1)
                {
                    result.Push(firstTimeline[row - 1]);
                    row--;
                    col--;
                }
                else if (table[row - 1, col] > table[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }
        }

        private static int LongestCommonSubsequence(int[,] table, int[] firstTimeline, int[] secondTimeline)
        {
            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (firstTimeline[r - 1] == secondTimeline[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }

            return table[firstTimeline.Length, secondTimeline.Length];
        }
    }
}
