using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Exam
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var taskToBeKilled = int.Parse(Console.ReadLine());
            var thread = 0;

            while (threads.Any() && tasks.Any())
            {
                var lastTask = tasks.Peek();
                var firstThread = threads.Peek();

                if (firstThread >= lastTask)
                {
                    tasks.Pop();

                    if (lastTask == taskToBeKilled)
                    {
                        thread = firstThread;
                        break;
                    }

                    threads.Dequeue();
                }
                else
                {
                    if (lastTask == taskToBeKilled)
                    {
                        thread = firstThread;
                        break;
                    }

                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {thread} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
