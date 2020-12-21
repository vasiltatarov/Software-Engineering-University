using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_SumOfCoins
{
    class StartUp
    {
        static void Main()
        {
            try
            {
                var coins = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                var target = int.Parse(Console.ReadLine());

                var sortedCoins = coins.OrderByDescending(x => x).ToList();
                var result = new Dictionary<int, int>();

                var counter = Greedy(target, sortedCoins, result);

                PrintResult(counter, result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static int Greedy(int target, List<int> sortedCoins, Dictionary<int, int> result)
        {
            var coinIdx = 0;
            var counter = 0;

            while (target > 0 && coinIdx < sortedCoins.Count)
            {
                var currentCoin = sortedCoins[coinIdx];
                var coinsCount = target / currentCoin;
                coinIdx++;

                if (coinsCount > 0)
                {
                    result.Add(currentCoin, coinsCount);

                    counter += coinsCount;
                    target -= currentCoin * coinsCount;
                }
            }

            if (target > 0)
            {
                throw new InvalidOperationException("Error");
            }

            return counter;
        }

        private static void PrintResult(int counter, Dictionary<int, int> result)
        {
            Console.WriteLine($"Number of coins to take: {counter}");

            foreach (var (coin, times) in result)
            {
                Console.WriteLine($"{times} coin(s) with value {coin}");
            }
        }
    }
}
