using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Cinema
{
    class StartUp
    {
        private static List<string> names;
        private static bool[] lockedSeats;
        private static string[] seats;

        static void Main()
        {
            names = Console.ReadLine().Split(", ").ToList();

            lockedSeats = new bool[names.Count];
            seats = new string[names.Count];

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "generate")
                {
                    break;
                }

                var args = command.Split(" - ");
                var name = args[0];
                var position = int.Parse(args[1]);

                lockedSeats[position - 1] = true;
                seats[position - 1] = name;

                names.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= names.Count)
            {
                var nameIndex = 0;

                for (int i = 0; i < seats.Length; i++)
                {
                    if (lockedSeats[i])
                    {
                        continue;
                    }

                    seats[i] = names[nameIndex];
                    nameIndex += 1;
                }

                Console.WriteLine(string.Join(" ", seats));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < names.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }
    }
}
