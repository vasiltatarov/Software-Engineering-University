using System;

namespace BinarySearch
{
    public class BinarySearch<T> where T : IComparable
    {
        public static int Search(T[] arr, int lo, int hi, T searchedElement)
        {
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;

                if (arr[mid].CompareTo(searchedElement) == 0)
                {
                    return mid;
                }
                if (arr[mid].CompareTo(searchedElement) > 0)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return -1;
        }
    }
}
