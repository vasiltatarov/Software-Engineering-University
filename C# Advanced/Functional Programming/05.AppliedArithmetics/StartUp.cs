using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], int[]> addOneToEachNumber = (arr) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] += 1;
                }

                return arr;
            };
            Func<int[], int[]> multiplyEachNumberByTwo = (arr) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] *= 2;
                }

                return arr;
            };
            Func<int[], int[]> subtractOneFromEachNumber = (arr) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] -= 1;
                }

                return arr;
            };

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    return;
                }

                if (command == "add")
                {
                    ProcessOperation(numbers, addOneToEachNumber);
                }
                else if (command == "multiply")
                {
                    ProcessOperation(numbers, multiplyEachNumberByTwo);
                }
                else if (command == "subtract")
                {
                    ProcessOperation(numbers, subtractOneFromEachNumber);
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }

        private static void ProcessOperation(int[] numbers, Func<int[], int[]> addOneToEachNumber)
        {
            numbers = addOneToEachNumber.Invoke(numbers);
        }
    }
}
