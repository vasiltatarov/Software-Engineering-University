using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END")
                {
                    break;
                }

                var name = input[0];
                var age = int.Parse(input[1]);
                var town = input[2];

                var person = new Person(name, age, town);
                people.Add(person);
            }

            var n = int.Parse(Console.ReadLine());
            var personToCompare = people[n - 1];
            var countMatches = 0;

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    countMatches++;
                }
            }

            if (countMatches > 1)
            {
                Console.WriteLine($"{countMatches} {people.Count - countMatches} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
