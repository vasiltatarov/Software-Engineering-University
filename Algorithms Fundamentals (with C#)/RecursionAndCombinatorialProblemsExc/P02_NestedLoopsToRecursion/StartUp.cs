using System;

namespace P02_NestedLoopsToRecursion
{
    class StartUp
    {
        private static int n;
        private static int[] result;

        static void Main()
        { 
            n = int.Parse(Console.ReadLine());
            result = new int[n];

            NestedLoops(0);
        }

        private static void NestedLoops(int index)
        {
            if (index == result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                result[index] = i;
                NestedLoops(index + 1);
            }
        }
    }
}
