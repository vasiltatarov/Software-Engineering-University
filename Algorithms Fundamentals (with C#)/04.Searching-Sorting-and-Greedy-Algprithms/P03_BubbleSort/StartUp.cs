using System;
using System.Linq;

namespace P03_BubbleSort
{
    class StartUp
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            BubbleSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var isOrdered = true;

                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        isOrdered = false;
                        Swap(j, j + 1, arr);
                    }
                }

                if (isOrdered)
                {
                    return;
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
