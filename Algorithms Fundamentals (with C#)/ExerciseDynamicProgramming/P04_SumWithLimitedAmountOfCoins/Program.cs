using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_SumWithLimitedAmountOfCoins
{
    class Program
    {
        static void Main()
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            var sums = GetSums(coins);
            Console.WriteLine(sums[target]);
        }

        private static Dictionary<int, int> GetSums(int[] coins)
        {
            var result = new Dictionary<int, int> {{0, 1}};

            foreach (var coin in coins)
            {
                var sums = result.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var newSum = sum + coin;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, 0);
                    }

                    result[newSum]++;
                }
            }

            return result;
        }
    }
}
