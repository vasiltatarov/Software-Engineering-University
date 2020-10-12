using System;

namespace Selection_Sort
{
    class StartUp
    {
        static void Main()
        {
            var arr = new int[] { 10, 4, 7, 34, 1, 45, 97, 2, 9, 77 };

            SelectionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        public static void SelectionSort(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                var min = index;

                for (int curr = index + 1; curr < arr.Length; curr++)
                {
                    if (arr[curr] < arr[min])
                    {
                        min = curr;
                    }
                }

                Swap(arr, index, min);
            }
        }

        private static void Swap(int[] arr, int index, int min)
        {
            var temp = arr[index];

            arr[index] = arr[min];
            arr[min] = temp;
        }
    }
}
