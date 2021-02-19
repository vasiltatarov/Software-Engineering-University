using System;
using System.Linq;

namespace _03._Road_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            var itemValues = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var spaces = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var maxCapacity = int.Parse(Console.ReadLine());

            var dp = new int[itemValues.Length + 1, maxCapacity + 1];

            for (int item = 1; item < dp.GetLength(0); item++)
            {
                var itemValue = itemValues[item - 1];
                var itemSpace = spaces[item - 1];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    if (capacity < itemSpace)
                    {
                        dp[item, capacity] = dp[item - 1, capacity];
                    }
                    else
                    {
                        dp[item, capacity] = Math.Max(dp[item - 1, capacity],
                            dp[item - 1, capacity - itemSpace] + itemValue);
                    }
                }
            }

            Console.WriteLine($"Maximum value: {dp[itemValues.Length, maxCapacity]}");
        }
    }
}
