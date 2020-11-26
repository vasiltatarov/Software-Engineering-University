using System;
using System.Collections.Generic;

namespace P04_CombinationsWithoutRepetition
{
    class StartUp
    {
        private static int n;
        private static int k;
        private static int[] combinations;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());
            combinations = new int[k];

            Combination(0, 1);
        }

        private static void Combination(int index, int elementsStartIndex)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i <= n; i++)
            {
                combinations[index] = i;
                Combination(index + 1, i + 1);
            }
        }
    }
}
