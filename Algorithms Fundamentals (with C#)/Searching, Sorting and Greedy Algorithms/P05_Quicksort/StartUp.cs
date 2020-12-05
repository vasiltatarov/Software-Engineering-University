using System;
using System.Linq;

namespace P05_Quicksort
{
    class StartUp
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Quicksort(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Quicksort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var leftIdx = start + 1;
            var rightIdx = end;

            while (leftIdx <= rightIdx)
            {
                if (arr[leftIdx] > arr[pivot] && 
                    arr[rightIdx] < arr[pivot])
                {
                    Swap(arr, leftIdx, rightIdx);
                }

                if (arr[leftIdx] <= arr[pivot])
                {
                    leftIdx++;
                }

                if (arr[rightIdx] >= arr[pivot])
                {
                    rightIdx--;
                }
            }

            Swap(arr, pivot, rightIdx);

            var isSubLeftArraySmaller = rightIdx - 1 - start < end - (rightIdx + 1);

            if (isSubLeftArraySmaller)
            {
                Quicksort(arr, start, rightIdx - 1);
                Quicksort(arr, rightIdx + 1, end);
            }
            else
            {
                Quicksort(arr, rightIdx + 1, end);
                Quicksort(arr, start, rightIdx - 1);
            }
        }

        private static void Swap(int[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
