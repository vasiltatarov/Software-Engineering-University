using System;
using System.Linq;

namespace P01_RecursiveArraySum
{
    public class StartUp
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(RecursiveArraySum(arr, 0));
        }

        private static long RecursiveArraySum(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                return 0;
            }

            return arr[index] + RecursiveArraySum(arr, index + 1);
        }
    }
}
