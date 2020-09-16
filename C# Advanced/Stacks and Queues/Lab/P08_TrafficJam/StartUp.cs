using System;
using System.Collections.Generic;

namespace P08_TrafficJam
{
    public class StartUp
    {
        static void Main()
        {
            var countPassingCars = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var passedCars = 0;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command == "green")
                {
                    for (int i = 0; i < countPassingCars; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            passedCars++;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
