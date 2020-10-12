using System;

namespace Bubble_Sort
{
    class StartUp
    {
        static void Main()
        {
            BubbleSort bs = new BubbleSort();

            var arr = bs.CreateRandomArray(30);
            var sortedArr = bs.Sort(arr);

            Console.WriteLine(string.Join(", ", sortedArr));
        }
    }
}
