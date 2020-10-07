using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                var currPerson = Console.ReadLine().Split(" ");
                var name = currPerson[0];
                var age = int.Parse(currPerson[1]);

                var person = new Person(name, age);

                family.AddMember(person);
            }

            PrintMembers(family);
        }

        private static void PrintMembers(Family family)
        {
            foreach (var person in family.Members)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
