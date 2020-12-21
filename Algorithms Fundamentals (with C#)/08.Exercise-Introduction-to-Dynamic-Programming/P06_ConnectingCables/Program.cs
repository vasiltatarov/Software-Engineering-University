using System;
using System.Linq;

namespace P06_ConnectingCables
{
    class Program
    {
        static void Main()
        {
            var cables = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var oppositeSides = new int[cables.Length];

            for (int i = 0; i < oppositeSides.Length; i++)
            {
                oppositeSides[i] = i + 1;
            }

            var table = new int[cables.Length + 1, cables.Length + 1];
            var count = ConnectedCables(table, cables, oppositeSides);

            Console.WriteLine($"Maximum pairs connected: {count}");
        }

        private static int ConnectedCables(int[,] table, int[] cables, int[] oppositeSides)
        {
            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (cables[r - 1] == oppositeSides[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }

            return table[cables.Length, oppositeSides.Length];
        }
    }
}
