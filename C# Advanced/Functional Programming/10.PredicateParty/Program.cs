using System;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main()
        {
            var guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Party!")
                {
                    break;
                }

                var args = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var cmdType = args[0];
                var predicateArgs = args.Skip(1).ToArray();

                Predicate<string> predicate = GetPredicateArgs(predicateArgs);

                if (cmdType == "Double")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        var current = guests[i];

                        if (predicate(current))
                        {
                            guests.Insert(i + 1, current);
                            i++;
                        }
                    }
                }
                else if (cmdType == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
        }

        public static Predicate<string> GetPredicateArgs(string[] predicateArgs)
        {
            var prType = predicateArgs[0];
            var prArgs = predicateArgs[1];
            Predicate<string> predicate = null;

            if (prType == "StartsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.StartsWith(prArgs);
                });
            }
            else if (prType == "EndsWith")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.EndsWith(prArgs);
                });
            }
            else if (prType == "Length")
            {
                predicate = new Predicate<string>((name) =>
                {
                    return name.Length == int.Parse(prArgs);
                });
            }

            return predicate;
        }
    }
}
