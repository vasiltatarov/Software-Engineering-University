using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int> smallestNumber = (arr) =>
            {
                var minNumber = int.MaxValue;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < minNumber)
                    {
                        minNumber = arr[i];
                    }
                }

                return minNumber;
            };

            if (numbers.Length == 0)
            {
                return;
            }

            var minNum = smallestNumber.Invoke(numbers);
            Console.WriteLine(minNum);

        }

        //private static Func<int[], int> SmallestNumber = (arr) =>
        //{
        //    var minNumber = int.MaxValue;

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (arr[i] < minNumber)
        //        {
        //            minNumber = arr[i];
        //        }
        //    }

        //    return minNumber;
        //};
    }
}
