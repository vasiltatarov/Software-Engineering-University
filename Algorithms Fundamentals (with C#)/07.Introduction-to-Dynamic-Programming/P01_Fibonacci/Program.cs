using System;
using System.Collections.Generic;

namespace P01_Fibonacci
{
    class Program
    {
        private static Dictionary<int, long> memo;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            memo = new Dictionary<int, long>();
            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            var result = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            memo.Add(n, result);

            return result;
        }
    }
}
