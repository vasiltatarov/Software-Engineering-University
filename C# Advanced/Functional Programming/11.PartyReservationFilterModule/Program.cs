using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main()
        {
            var invitations = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var filters = new HashSet<string>();

            while (true)
            {
                var filter = Console.ReadLine();

                if (filter == "Print")
                {
                    break;
                }

                if (filter.StartsWith("Add"))
                {
                    filters.Add(filter);
                }
                else if (filter.StartsWith("Remove"))
                {
                    filter = filter.Remove(0, 7);

                    filters.Remove($"Add {filter}");
                }
            }

            foreach (var filter in filters)
            {
                Predicate<string> predicate = GetPredicate(filter);

                if (predicate != null)
                {
                    invitations.RemoveAll(predicate);
                }
            }

            Console.WriteLine(string.Join(" ", invitations));
        }

        private static Predicate<string> GetPredicate(string filter)
        {
            var args = filter.Split(";");
            var filterType = args[1];
            var filterName = args[2];

            Predicate<string> predicate = null;

            if (filterType == "Starts with")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.StartsWith(filterName);
                });
            }
            else if (filterType == "Ends with")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.EndsWith(filterName);
                });
            }
            else if (filterType == "Length")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.Length == int.Parse(filterName);
                });
            }
            else if (filterType == "Contains")
            {
                predicate = new Predicate<string>((name) =>
                {
                   return name.Contains(filterName);
                });
            }

            return predicate;
        }
    }
}
