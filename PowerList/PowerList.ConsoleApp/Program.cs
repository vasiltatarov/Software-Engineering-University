using System.Collections.Generic;

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

            Console.WriteLine("Count " + list.Count);

            //var listAsEnumerable = GetListAsEnumerable();

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }



            // Power List
            Console.WriteLine("\nPower List\n");
            var powerList = new PowerList<int>();
            Console.WriteLine("Count " + powerList.Count);

            for (int i = 0; i < 10; i++)
            {
                powerList.Add(i);
            }

            Console.WriteLine("Count " + list.Count);

            //var powerListAsEnumerable = GetPowerListAsEnumerable();

            foreach (var i in powerList)
            {
                Console.WriteLine(i);
            }
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
