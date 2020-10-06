using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main()
        {
            var boundsOfNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var lowerBound = boundsOfNumbers[0];
            var upperBound = boundsOfNumbers[1];
            var commandForOddOrEven = Console.ReadLine();

            Predicate<int> findEvenOrOdds = commandForOddOrEven
                == "odd" ? new Predicate<int>(x => x % 2 != 0) : new Predicate<int>(x => x % 2 == 0);

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (findEvenOrOdds(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
