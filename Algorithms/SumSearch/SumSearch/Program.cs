using System;
using System.Collections.Generic;
using System.Linq;

namespace SumSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            FindPairsIndex(arr, target);
        }
        
        // With optimization
        public static void FindPairsIndex(int[] arr, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(target - arr[i]))
                {
                    Console.WriteLine($"[{dict[target - arr[i]]}, {i}]");
                    return;
                }

                if (!dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i], i);
                }
            }

            Console.WriteLine($"Not found!");
        }

        private static void FindPairsSum(int[] arr, int target)
        {
            var isMatch = false;

            for (int i = 0; i < arr.Length; i++)
            {
                var first = arr[i];

                for (int j = 0; j < arr.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    var second = arr[j];
                    var sum = first + second;

                    if (sum == target)
                    {
                        isMatch = true;
                        Console.WriteLine($"Have match! First number is {first} on index:{{{i}}}, second number is {second} on index:{{{j}}}.");
                        break;
                    }
                }

                if (isMatch)
                {
                    break;
                }
            }

            if (!isMatch)
            {
                Console.WriteLine($"No match!");
            }
        }

        public static void FindPairsSumWithOrderedArray(int[] arr, int target)//00:00:00.0006429 -- 5719
        {
            var low = 0;
            var high = arr.Length - 1;

            while (low < high)
            {
                if (arr[low] + arr[high] > target)
                {
                    high--;
                }
                else if (arr[low] + arr[high] < target)
                {
                    low++;
                }
                else if (arr[low] + arr[high] == target)
                {
                    Console.WriteLine($"[{low}, {high}]");
                    break;
                }
            }
        }
    }
}