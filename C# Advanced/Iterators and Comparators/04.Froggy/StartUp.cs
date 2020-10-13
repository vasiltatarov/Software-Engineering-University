using System;
using System.Linq;

namespace _02.Froggy
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var lake = new Lake(numbers);

            Console.WriteLine(lake);
        }
    }
}
