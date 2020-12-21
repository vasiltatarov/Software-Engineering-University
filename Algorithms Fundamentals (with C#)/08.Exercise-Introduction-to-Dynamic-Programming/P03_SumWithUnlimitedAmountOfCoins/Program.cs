using System;
using System.Linq;

namespace P03_SumWithUnlimitedAmountOfCoins
{
    class Program
    {
        static void Main()
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            var sums = GenerateSums(coins, target);

            Console.WriteLine(sums[target]);
        }

        private static int[] GenerateSums(int[] coins, int target)
        {
            var sums = new int[target + 1];
            sums[0] = 1;

            foreach (var coin in coins)
            {
                for (int i = coin; i < sums.Length; i++)
                {
                    sums[i] += sums[i - coin];
                }
            }

            return sums;
        }
    }
}
