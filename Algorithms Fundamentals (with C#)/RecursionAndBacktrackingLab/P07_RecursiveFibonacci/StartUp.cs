using System;

namespace P07_RecursiveFibonacci
{
    public class StartUp
    {
        //Memoization
        private static long[] memo;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            memo = new long[n + 1];
            Console.WriteLine(Fibonacci(n));
        }

        // Recursive fibonacci with DP + memo
        private static long Fibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);

            return memo[n];
        }

        //Fibonacci without Recursion
        private static long IterativeFibonacci(int n)
        {
            memo = new long[n + 1];

            memo[0] = 1;
            memo[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }

            return memo[n];
        }
    }
}
