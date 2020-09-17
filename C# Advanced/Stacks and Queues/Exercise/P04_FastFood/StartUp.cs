using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_FastFood
{
    public class StartUp
    {
        static void Main()
        {
            var foodQuantity = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                var order = queue.Peek();

                if (foodQuantity >= order)
                {
                    queue.Dequeue();
                    foodQuantity -= order;
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
