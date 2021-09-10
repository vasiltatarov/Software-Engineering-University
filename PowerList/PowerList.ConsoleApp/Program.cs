using System.Collections.Generic;
using System.Linq;

namespace PowerList.ConsoleApp
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // .NET List
            Console.WriteLine(".NET List\n");

            var list = new List<int>();
            Console.WriteLine("Count " + list.Count);

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list.Add(999);

            Console.WriteLine("Count " + list.Count);
            Console.WriteLine(list.Contains(1));
            Console.WriteLine(list.Contains(1111));
            Console.WriteLine("IndexOf " + list.IndexOf(999));

            list[1] = 555;
            Console.WriteLine(list[1]);

            list.RemoveAt(1);
            Console.WriteLine(list[1]);

            Console.WriteLine(list.Remove(999));
            Console.WriteLine(list.Count);

            list.Insert(2, 434);
            Console.WriteLine("Count " + list.Count);

            Console.WriteLine();
            Console.WriteLine(string.Join(", ", list));

            var evenNumbers = list.Where(x => x % 2 == 0).ToList();
            Console.WriteLine(string.Join(", ", evenNumbers));

            // Power List
            Console.WriteLine("\nPower List\n");
            var powerList = new PowerList<int>();
            Console.WriteLine("Count " + powerList.Count);

            for (int i = 0; i < 10; i++)
            {
                powerList.Add(i);
            }

            powerList.Add(999);

            Console.WriteLine("Count " + powerList.Count);
            Console.WriteLine(powerList.Contains(1));
            Console.WriteLine(powerList.Contains(1111));
            Console.WriteLine("IndexOf " + powerList.IndexOf(999));

            powerList[1] = 555;
            Console.WriteLine(powerList[1]);

            powerList.RemoveAt(1);
            Console.WriteLine(powerList[1]);

            Console.WriteLine(powerList.Remove(999));
            Console.WriteLine(powerList.Count);

            powerList.Insert(2, 434);
            Console.WriteLine("Count " + powerList.Count);

            powerList.AddAtBottom(123);
            Console.WriteLine("Count " + powerList.Count);

            Console.WriteLine(powerList.RemoveFirst());
            Console.WriteLine("Count " + powerList.Count);

            Console.WriteLine();
            Console.WriteLine(string.Join(", ", powerList));

            var evenNumbersPowerList = powerList
                .Where(x => x % 2 == 0);
            Console.WriteLine(string.Join(", ", evenNumbersPowerList));
        }

        private static IEnumerable<int> GetListAsEnumerable()
        {
            return new List<int> { 1, 2, 3, 4 };
        }

        private static IEnumerable<int> GetPowerListAsEnumerable()
        {
            var powerList = new PowerList<int> {1, 2};

            return powerList;
        }
    }
}
