using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_TruckTour
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                var pump = Console.ReadLine();
                pump += $" {i}";
                queue.Enqueue(pump);
            }

            var totalFuel = 0;

            for (int i = 0; i < n; i++)
            {
                var currPump = queue.Dequeue();
                var args = currPump.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var petrolAmount = args[0];
                var distanceToNextPump = args[1];

                totalFuel += petrolAmount;

                if (totalFuel >= distanceToNextPump)
                {
                    totalFuel -= distanceToNextPump;
                }
                else
                {
                    totalFuel = 0;
                    i = -1;
                }

                queue.Enqueue(currPump);
            }

            var bestIndexToStart = queue.Dequeue().Split();

            Console.WriteLine(bestIndexToStart[2]);
        }
    }
}
