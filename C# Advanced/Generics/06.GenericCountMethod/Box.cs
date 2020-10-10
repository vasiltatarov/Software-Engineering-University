using System;
using System.Collections.Generic;

namespace _06.GenericCountMethod
{
    public static class Box<T> where T : IComparable
    {
        public static int CountGreaterElements(List<T> list, T comparisonElement)
        {
            var counter = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(comparisonElement) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
