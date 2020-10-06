using System;

namespace _01.ActionPoint
{
    public class Program
    {
        static void Main()
        {
            Action<string[]> print = (arr) =>
            {
                foreach (var name in arr)
                {
                    Console.WriteLine(name);
                }
            };

            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            print.Invoke(names);
        }
    }
}
