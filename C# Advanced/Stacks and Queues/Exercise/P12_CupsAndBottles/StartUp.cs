using System;
using System.Collections.Generic;
using System.Linq;

namespace P12_CupsAndBottles
{
    public class StartUp
    {
        static void Main()
        {
            var cupsCapacity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var filledBottles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var cups = new Queue<int>(cupsCapacity);
            var bottles = new Stack<int>(filledBottles);
            int totalWastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                var currCup = cups.Dequeue();

                while (currCup > 0 && bottles.Any())
                {
                    currCup -= bottles.Pop();
                }

                totalWastedWater += Math.Abs(currCup);
            }

            if (cups.Count != 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else if (bottles.Count != 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {totalWastedWater}");
        }
    }
}
