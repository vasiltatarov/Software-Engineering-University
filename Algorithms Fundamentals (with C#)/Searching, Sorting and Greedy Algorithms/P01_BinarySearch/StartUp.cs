using System;
using System.Linq;

namespace P01_BinarySearch
{
    class StartUp
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var searchingElement = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(arr, searchingElement));
        }

        public static int BinarySearch(int[] arr, int key)
        {
            var left = 0;
            var right = arr.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;
                var element = arr[mid];

                if (key == element)
                {
                    return mid;
                }

                if (key > element)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}
