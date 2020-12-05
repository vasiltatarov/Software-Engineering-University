using System;
using System.Linq;

namespace P02_SelectionSort
{
    class StartUp
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SelectionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var currentElement = arr[i];
                var index = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < currentElement)
                    {
                        currentElement = arr[j];
                        index = j;
                    }
                }

                if (i != index)
                {
                    Swap(i, index, arr);
                }
            }
        }

        private static void Swap(int first, int second, int[] arr)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
