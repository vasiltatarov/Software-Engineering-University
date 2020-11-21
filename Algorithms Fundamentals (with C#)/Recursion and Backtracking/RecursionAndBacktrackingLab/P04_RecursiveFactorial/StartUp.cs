using System;

namespace P04_RecursiveFactorial
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }

        private static long Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
