using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var name = args[0];
                var age = int.Parse(args[1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, age);
                }
            }

            var conditon = Console.ReadLine(); // "younger" or "older"
            var ageFormat = int.Parse(Console.ReadLine());
            var format = Console.ReadLine(); // "name", "age" or "name age"

            dict = ReadConditionAndAgeFormat(dict, conditon, ageFormat);
            PrintInFormat(dict, format);
        }

        private static void PrintInFormat(Dictionary<string, int> dict, string format)
        {
            if (format == "name")
            {
                foreach (var (name, age) in dict)
                {
                    Console.WriteLine(name);
                }
            }
            else if (format == "age")
            {
                foreach (var (name, age) in dict)
                {
                    Console.WriteLine(age);
                }
            }
            else if (format == "name age")
            {
                foreach (var (name, age) in dict)
                {
                    Console.WriteLine($"{name} - {age}");
                }
            }
        }

        private static Dictionary<string, int> ReadConditionAndAgeFormat(Dictionary<string, int> dict, string conditon, int ageFormat)
        {
            if (conditon == "younger")
            {
                dict = dict.Where(x => x.Value < ageFormat).ToDictionary(x => x.Key, x => x.Value);
            }
            else if (conditon == "older")
            {
                dict = dict.Where(x => x.Value >= ageFormat).ToDictionary(x => x.Key, x => x.Value);
            }

            return dict;
        }
    }
}
