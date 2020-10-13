using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    public class StartUp
    {
        public static void Main()
        {
            var set = new HashSet<Person>();
            var sortedSet = new SortedSet<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);
                set.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(set.Count);
        }
    }
}
