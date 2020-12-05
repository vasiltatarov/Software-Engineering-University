using System;
using System.Linq;

namespace P04_InsertionSort
{
    class StartUp
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            InsertionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var j = i;

                while (j > 0 && arr[j - 1] > arr[j])
                {
                    Swap(arr, j - 1, j);
                    j--;
                }
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
