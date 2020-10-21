using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_ClubParty
{
    public class Program
    {
        public static void Main()
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            var input = new Stack<string>(Console.ReadLine().Split());

            var halls = new Queue<string>();
            var guests = new List<int>();
            var currentCapacity = 0;

            while (input.Any())
            {
                var currElement = input.Pop();

                var isParsed = int.TryParse(currElement, out int reservation);

                if (isParsed)
                {
                    if (currentCapacity + reservation > maxCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", guests)}");
                        guests.Clear();
                        currentCapacity = 0;
                    }

                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    guests.Add(reservation);
                    currentCapacity += reservation;
                }
                else
                {
                    halls.Enqueue(currElement);
                }
            }
        }
    }
}
