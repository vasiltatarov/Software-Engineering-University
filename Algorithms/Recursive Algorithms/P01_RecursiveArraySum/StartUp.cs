using System;
using System.Linq;

namespace P01_RecursiveArraySum
{
    public class StartUp
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(FindSumRecursion(arr, 0, 0));
        }

        private static int FindSumRecursion(int[] arr, int currentIndex, int sum)
        {
            if (currentIndex == arr.Length)
            {
                return sum;
            }
            else
            {
                return FindSumRecursion(arr, currentIndex + 1, sum + arr[currentIndex]);
            }
        }
    }
}
