﻿using System;
using System.Linq;

namespace P01_RodCutting
{
    class Program
    {
        private static int[] bestPrices;
        private static int[] combo;

        static void Main()
        {
            var prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var length = int.Parse(Console.ReadLine());

            bestPrices = new int[length + 1];
            combo = new int[length + 1];
            var bestLength = CutRod(length, prices);

            PrintResult(bestLength, length);
        }

        private static void PrintResult(int bestLength, int length)
        {
            Console.WriteLine(bestLength);

            while (length != 0)
            {
                Console.Write($"{combo[length]} ");
                length -= combo[length];
            }
        }

        private static int CutRod(int length, int[] prices)
        {
            if (length == 0)
            {
                return 0;
            }

            if (bestPrices[length] != 0)
            {
                return bestPrices[length];
            }

            var bestPrice = prices[length];
            var bestCombo = length;

            for (int i = 1; i < length; i++)
            {
                var currentPrice = prices[i] + CutRod(length - i, prices);

                if (currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                    bestCombo = i;
                }
            }

            bestPrices[length] = bestPrice;
            combo[length] = bestCombo;

            return bestPrice;
        }
    }
}
