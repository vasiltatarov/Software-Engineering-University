using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_ReverseArray
{
    class StartUp
    {
        private static int[] initialArr;
        private static List<int> resultArr;

        static void Main()
        {
            initialArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            resultArr = new List<int>();

            ReverseArray(initialArr.Length - 1);

            Console.WriteLine(string.Join(" ", resultArr));
        }

        private static void ReverseArray(int index)
        {
            if (index < 0)
            {
                return;
            }

            resultArr.Add(initialArr[index]);
            ReverseArray(index - 1);
        }
    }
}
