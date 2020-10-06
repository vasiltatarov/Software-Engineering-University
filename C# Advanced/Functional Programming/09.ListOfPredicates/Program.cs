using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int, bool> numberDivisibleByAll = (arr, x) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (x % arr[i] != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            for (int i = 1; i <= n; i++)
            {
                if (numberDivisibleByAll(dividers, i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
