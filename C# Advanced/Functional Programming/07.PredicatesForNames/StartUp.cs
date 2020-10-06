using System;
using System.Linq;

namespace _07.PredicatesForNames
{
    class Program
    {
        static void Main()
        {
            var nameLength = int.Parse(Console.ReadLine());

            Predicate<string> nameWithSameLength = x => x.Length <= nameLength;

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => nameWithSameLength(x)).ToList().ForEach(Console.WriteLine);
        }
    }
}
