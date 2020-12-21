using System;

namespace P07_N_Choose_K_Count
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(Combination(n, k));
        }

        private static int Combination(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return Combination(row - 1, col) + Combination(row - 1, col - 1);
        }
    }
}
