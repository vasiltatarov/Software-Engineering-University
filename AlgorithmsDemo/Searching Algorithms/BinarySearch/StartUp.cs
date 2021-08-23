using System;

namespace BinarySearch
{
    public class StartUp
    {
        // Algorithm complexity is O(Log n).
        static void Main()
        {
            var arr = new int[] { -1, 0, 1, 2, 4, 2, 43, 99, 342, 534, 564, 600, 700, 800, 999, 1233 };
            var searchedElement = 0;

            var index = BinarySearch<int>.Search(arr, 0, arr.Length - 1, searchedElement);

            Console.WriteLine($"Index of {searchedElement} is {index}");
        }

        // Binary Search with Recursion.
        private static int BinarySearchRecursive(int[] arr, int lo, int hi, int searchedElement)
        {
            var mid = (lo + hi) / 2;

            if (arr[mid] > searchedElement)
            {
                return BinarySearchRecursive(arr, lo, mid - 1, searchedElement);
            }
            else if (arr[mid] < searchedElement)
            {
                return BinarySearchRecursive(arr, mid + 1, hi, searchedElement);
            }
            else
            {
                return mid;
            }
        }
    }
}
