using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main()
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> action = (arr) =>
            {
                foreach (var name in arr)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            action.Invoke(names);
        }
    }
}
