using System;

namespace P03_Generating01Vectors
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var vector = new int[n];

            Gen01(vector, 0);
        }

        private static void Gen01(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01(vector, index + 1);
            }
        }
    }
}
