using System;
using System.Collections.Generic;

namespace P01_TwoMinutesToMidnight
{
    class Program
    {
        private static Dictionary<string, long> cache;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            cache = new Dictionary<string, long>();

            var ways = GetBinom(n, k);

            Console.WriteLine(ways);
        }

        private static long GetBinom(int row, int col)
        {
            if (col == 0 || col >= row)
            {
                return 1;
            }

            var key = $"{row} {col}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
            cache.Add(key, result);

            return result;
        }
    }
}
