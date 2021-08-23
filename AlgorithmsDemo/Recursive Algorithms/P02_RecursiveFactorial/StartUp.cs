using System;

namespace P02_RecursiveFactorial
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(FindFacturialRecursion(n));
        }

        public static int factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            var result = n * factorial(n - 1);
            return result;
        }
    }
}
