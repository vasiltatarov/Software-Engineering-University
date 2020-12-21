using System;

namespace P06_CombinationWithRepetition
{
    class StartUp
    {
        private static string[] elements;
        private static int k;
        private static string[] combination;

        static void Main()
        {
            elements = Console.ReadLine().Split();//new string[]{"A", "B", "C"};
            k = int.Parse(Console.ReadLine());
            combination = new string[k];

            Combination(0, 0);
        }

        private static void Combination(int index, int elementsStartIndex)
        {
            if (index >= combination.Length)
            {
                Console.WriteLine(string.Join(" ", combination));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combination[index] = elements[i];
                Combination(index + 1, i);
            }
        }
    }
}
