using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_DatingApp
{
    public class StartUp
    {
        static void Main()
        {
            var males = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var females = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(females);
            var stack = new Stack<int>(males);

            var matchesCount = 0;

            while (queue.Any() && stack.Any())
            {
                var firstFemale = queue.Peek();
                var lastMale = stack.Peek();

                if (firstFemale <= 0)
                {
                    queue.Dequeue();
                    continue;
                }

                if (lastMale <= 0)
                {
                    stack.Pop();
                    continue;
                }

                if (firstFemale % 25 == 0)
                {
                    queue.Dequeue();

                    if (queue.Any())
                    {
                        queue.Dequeue();
                    }

                    continue;
                }

                if (lastMale % 25 == 0)
                {
                    stack.Pop();

                    if (stack.Any())
                    {
                        stack.Pop();
                    }

                    continue;
                }

                

                if (firstFemale == lastMale)
                {
                    stack.Pop();
                    queue.Dequeue();
                    matchesCount++;
                }
                else
                {
                    queue.Dequeue();
                    stack.Pop();
                    lastMale -= 2;
                    stack.Push(lastMale);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            if (stack.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ", stack)}");
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", queue)}");
            }
        }
    }
}
