using System;
using System.Linq;

namespace P06_Mergesort
{
    class StartUp
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var sorted = MergeSort(arr);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }

            var left = arr.Take(arr.Length / 2).ToArray();
            var right = arr.Skip(arr.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergeIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merged[mergeIdx] = left[leftIdx];
                    leftIdx++;
                }
                else
                {
                    merged[mergeIdx] = right[rightIdx];
                    rightIdx++;
                }

                mergeIdx++;
            }

            while (leftIdx < left.Length)
            {
                merged[mergeIdx] = left[leftIdx];
                leftIdx++;
                mergeIdx++;
            }

            while (rightIdx < right.Length)
            {
                merged[mergeIdx] = right[rightIdx];
                rightIdx++;
                mergeIdx++;
            }

            return merged;
        }
    }
}
