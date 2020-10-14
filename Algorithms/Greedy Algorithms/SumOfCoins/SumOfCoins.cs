using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main()
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        try
        {
            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            PrintResult(selectedCoins);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var dict = new Dictionary<int, int>();
        var sortedCoins = coins.OrderByDescending(c => c).ToList();
        var coinIndex = 0;

        while (targetSum > 0)
        {
            var currentCoin = sortedCoins[coinIndex];

            if (targetSum >= currentCoin)
            {
                targetSum -= currentCoin;

                if (!dict.ContainsKey(currentCoin))
                {
                    dict.Add(currentCoin, 0);
                }

                dict[currentCoin]++;
                continue;
            }
            else
            {
                coinIndex++;

                if (coinIndex == sortedCoins.Count)
                {
                    throw new InvalidOperationException("Error!");
                }
            }
        }


        return dict;
    }

    private static void PrintResult(Dictionary<int, int> selectedCoins)
    {
        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");

        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }
}