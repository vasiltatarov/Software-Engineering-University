using System;
using System.Collections.Generic;

namespace P07_HotPotato
{
    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var kids = new Queue<string>(input);
            var n = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    var currKid = kids.Dequeue();
                    kids.Enqueue(currKid);
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
