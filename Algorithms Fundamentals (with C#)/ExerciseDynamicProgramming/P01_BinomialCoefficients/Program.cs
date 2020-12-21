using System;
using System.Collections.Generic;

namespace P01_BinomialCoefficients
{
    class Program
    {
        private static Dictionary<string, long> cache;

        static void Main()
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());
            cache = new Dictionary<string, long>();

            Console.WriteLine(GetBinomial(row, col));
        }

        private static long GetBinomial(int row, int col)
        {
            var key = $"{row} {col}";

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            if (col == 0 || col >= row)
            {
                return 1;
            }

            var result = GetBinomial(row - 1, col - 1) + GetBinomial(row - 1, col);
            cache.Add(key, result);

            return result;
        }
    }
}
