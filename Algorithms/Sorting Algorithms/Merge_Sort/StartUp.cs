using System;

namespace Merge_Sort
{
    public class StartUp
    {
        public static void Main()
        {
            var arr = new int[] { 5, 4, 3, 2, 1, 32, 455, 2, 54, 6, 8, 6, 5, 34, 23, 2, 12 };

            Console.WriteLine("Unsorted Array!");
            PrintArray(arr);

            var merge = new MergeSort();
            merge.Sort(arr, 0, arr.Length - 1);

            Console.WriteLine("Sorted Array!");
            PrintArray(arr);
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine();
        }
    }
}
