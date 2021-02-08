using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_CableMerchant
{
    class Program
    {
        private static List<int> prices;
        private static int[] bestPrices;
        private static int connectorPrice;

        static void Main(string[] args)
        {
            prices = new List<int> {0};
            prices.AddRange(Console.ReadLine().Split().Select(int.Parse));

            connectorPrice = int.Parse(Console.ReadLine());

            bestPrices = new int[prices.Count];

            for (int i = 1; i < prices.Count; i++)
            {
                var bestPrice = CutCable(i);
                Console.Write($"{bestPrice} ");
            }
        }

        private static int CutCable(int length)
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

            for (int i = 1; i < length; i++)
            {
                var currentPrice = prices[i] + CutCable(length - i) - 2 * connectorPrice;

                if (currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                }
            }

            bestPrices[length] = bestPrice;
            return bestPrice;
        }
    }
}
