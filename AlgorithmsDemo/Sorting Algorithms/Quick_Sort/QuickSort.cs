using System;

namespace Quick_Sort
{
    public class QuickSort
    {
        public static void Main()
        {
            int[] arr = { 10, 7, 8, 9, 1, 5 };
            int n = arr.Length;
            Quicksort(arr, 0, n - 1);
            Console.WriteLine("sorted array ");
            printArray(arr, n);
        }

        public static void Quicksort(int[] arr, int low, int hight)
        {
            if (low < hight)
            {
                var pivot = Partision(arr, low, hight);

                Quicksort(arr, low, pivot - 1);
                Quicksort(arr, pivot + 1, hight);
            }
        }

        public static int Partision(int[] arr, int low, int hight)
        {
            var pivot = arr[hight];
            int i = low - 1;

            for (int j = low; j < hight; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, j, i);
                }
            }

            Swap(arr, i + 1, hight);

            return i + 1;
        }

        static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}