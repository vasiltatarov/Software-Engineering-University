using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = int.Parse(Console.ReadLine());

            Predicate<int> devisibleByN = (x) => x % n != 0;
            Func<int[], List<int>> reverseAndExcludeNumbers = (arr) =>
            {
                var resultedList = new List<int>();

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (devisibleByN(arr[i]))
                    {
                        resultedList.Add(arr[i]);
                    }
                }

                return resultedList;
            };

            var result = reverseAndExcludeNumbers.Invoke(numbers);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
