using Bubble_Sort.Contacts;
using System;
using System.ComponentModel;

namespace Bubble_Sort
{
    public class BubbleSort : ISortable
    {
        public int[] CreateRandomArray(int countElements)
        {
            ValidateSizeOfArray(countElements);

            var arr = new int[countElements];

            var random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(1, 1001);
            }

            return arr;
        }

        public int[] CreateRandomArray(int countElements, int from, int to)
        {
            ValidateSizeOfArray(countElements);

            var arr = new int[countElements];

            var random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(from, to);
            }

            return arr;
        }

        public int[] Sort(int[] array)
        {
            ValidateLengthOfArray(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int k = 0; k < array.Length - i - 1; k++)
                {
                    if (array[k] > array[k + 1])
                    {
                        var temp = array[k];

                        array[k] = array[k + 1];
                        array[k + 1] = temp;
                    }
                }
            }

            return array;
        }

        private void ValidateLengthOfArray(int[] array)
        {
            if (array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }
        }

        private void ValidateSizeOfArray(int countElements)
        {
            if (countElements <= 0)
            {
                throw new InvalidEnumArgumentException("Array size cannot be zero or negative!");
            }
        }
    }
}
