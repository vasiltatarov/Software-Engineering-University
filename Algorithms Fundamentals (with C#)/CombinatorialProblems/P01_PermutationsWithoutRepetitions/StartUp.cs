using System;

namespace CombinatorialProblems
{
    class StartUp
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;

        static void Main()
        {
            elements = new []{"A", "B", "C"};

            // Without optimization!!! 
            //permutations = new string[elements.Length];
            //used = new bool[elements.Length];
            //PermuteWithoutOptimization(0);

            // With optimization!!! 
            PermuteWithOptimization(0);
        }

        // All Permutations with optimization.
        private static void PermuteWithOptimization(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            PermuteWithOptimization(index + 1);

            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(index, i);
                PermuteWithOptimization(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        // All Permutations without optimization.
        private static void PermuteWithoutOptimization(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    //Pre-Action
                    used[i] = true;
                    permutations[index] = elements[i];

                    PermuteWithoutOptimization(index + 1);

                    //Post-Action
                    used[i] = false;
                }
            }
        }
    }
}
