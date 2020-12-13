using System;
using System.Collections.Generic;

namespace P03_LongestCommonSubsequence
{
    class Program
    {
        static void Main()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var lcs = new int[str1.Length + 1, str2.Length + 1];

            Console.WriteLine(LongestCommonSubsequence(lcs, str1, str2));

            var sequence = new Stack<char>();
            GetSequence(str1, str2, lcs, sequence);

            Console.WriteLine(string.Join("", sequence));
        }

        private static void GetSequence(string str1, string str2, int[,] lcs, Stack<char> sequence)
        {
            var row = str1.Length;
            var col = str2.Length;

            while (row > 0 && col > 0)
            {
                if (str1[row - 1] == str2[col - 1] &&
                    lcs[row, col] == lcs[row - 1, col - 1] + 1)
                {
                    sequence.Push(str1[row - 1]);
                    row--;
                    col--;
                }
                else if (lcs[row - 1, col] > lcs[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }
        }

        private static int LongestCommonSubsequence(int[,] lcs, string str1, string str2)
        {
            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r - 1, c], lcs[r, c - 1]);
                    }
                }
            }

            return lcs[str1.Length, str2.Length];
        }
    }
}
