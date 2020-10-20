using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_LootBox
{
    public class StartUp
    {
        static void Main()
        {
            var firstLootBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondLootBox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(firstLootBox);
            var stack = new Stack<int>(secondLootBox);
            var myCollection = 0;

            while (queue.Any() && stack.Any())
            {
                var firstItem = queue.Peek();
                var secondItem = stack.Pop();
                var sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    myCollection += sum;
                    queue.Dequeue();
                }
                else
                {
                    queue.Enqueue(secondItem);
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (myCollection >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {myCollection}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {myCollection}");
            }
        }
    }
}
