using System;
using System.Collections.Generic;

namespace P06_Supermarket
{
    public class StartUp
    {
        static void Main()
        {
            var queue = new Queue<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                if (command == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
