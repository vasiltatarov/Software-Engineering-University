using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_SetCover
{
    class StartUp
    {
        static void Main()
        {
            var set = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var n = int.Parse(Console.ReadLine());
            var sets = new List<int[]>();

            FillData(n, sets);

            var takedSets = new List<int[]>();

            FindBestSetsToTake(set, sets, takedSets);

            PrintTakedSets(takedSets);
        }

        private static void PrintTakedSets(List<int[]> takedSets)
        {
            Console.WriteLine($"Sets to take ({takedSets.Count}):");

            foreach (var currSet in takedSets)
            {
                Console.WriteLine(string.Join(", ", currSet));
            }
        }

        private static void FindBestSetsToTake(List<int> set, List<int[]> sets, List<int[]> takedSets)
        {
            while (set.Any())
            {
                var bestMatchesCount = 0;
                var bestIdx = 0;

                for (int i = 0; i < sets.Count; i++)
                {
                    var currentSet = sets[i];
                    var currentMachesCount = 0;

                    for (int j = 0; j < currentSet.Length; j++)
                    {
                        if (set.Contains(currentSet[j]))
                        {
                            currentMachesCount++;
                        }
                    }

                    if (currentMachesCount > bestMatchesCount)
                    {
                        bestMatchesCount = currentMachesCount;
                        bestIdx = i;
                    }
                }

                foreach (var value in sets[bestIdx])
                {
                    set.Remove(value);
                }

                takedSets.Add(sets[bestIdx]);
                sets.RemoveAt(bestIdx);
            }
        }

        private static void FillData(int n, List<int[]> sets)
        {
            for (int i = 0; i < n; i++)
            {
                sets.Add(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            }
        }
    }
}
