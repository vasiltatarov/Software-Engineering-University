using System;
using System.Collections.Generic;

namespace _06.GenericCountMethod
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                var value = double.Parse(Console.ReadLine());
                list.Add(value);
            }

            var comparisonValue = double.Parse(Console.ReadLine());

            var result = Box<double>.CountGreaterElements(list, comparisonValue);
            Console.WriteLine(result);
        }
    }
}
