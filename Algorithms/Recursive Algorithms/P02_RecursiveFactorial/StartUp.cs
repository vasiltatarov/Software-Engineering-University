using System;

namespace P02_RecursiveFactorial
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(FindFacturialRecursion(1, n));
        }

        private static int FindFacturialRecursion(int factotial, int n)
        {
            if (n == 1)
            {
                return factotial;
            }
            else
            {
                return FindFacturialRecursion(factotial * n, n - 1);
            }
        }
    }
}
