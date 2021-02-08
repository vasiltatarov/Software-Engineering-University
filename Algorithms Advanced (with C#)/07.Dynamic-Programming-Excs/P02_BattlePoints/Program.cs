using System;
using System.Linq;

namespace P02_BattlePoints
{
    class Program
    {
        static void Main()
        {
            var requiredEnergy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var battlePoints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var initialEnergy = int.Parse(Console.ReadLine());

            var enemies = requiredEnergy.Length;
            var dp = new int[enemies + 1, initialEnergy + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var enemyIdx = row - 1;

                var enemyEnergy = requiredEnergy[enemyIdx];
                var enemyBattlePoints = battlePoints[enemyIdx];

                for (int energy = 1; energy < dp.GetLength(1); energy++)
                {
                    var skip = dp[row - 1, energy];

                    if (enemyEnergy > energy)
                    {
                        dp[row, energy] = skip;
                        continue;
                    }

                    var take = enemyBattlePoints + dp[row - 1, energy - enemyEnergy];

                    if (take > skip)
                    {
                        dp[row, energy] = Math.Max(skip, take);
                    }
                    else
                    {
                        dp[row, energy] = skip;
                    }
                }
            }

            Console.WriteLine(dp[enemies, initialEnergy]);
        }
    }
}
