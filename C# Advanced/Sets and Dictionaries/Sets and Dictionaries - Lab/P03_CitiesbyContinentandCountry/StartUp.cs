using System;
using System.Collections.Generic;

namespace P04_CitiesbyContinentandCountry
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split();
                var continent = args[0];
                var country = args[1];
                var city = args[2];

                if (!dict.ContainsKey(continent))
                {
                    dict.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!dict[continent].ContainsKey(country))
                {
                    dict[continent].Add(country, new List<string>());
                }

                dict[continent][country].Add(city);
            }

            PrintData(dict);
        }

        private static void PrintData(Dictionary<string, Dictionary<string, List<string>>> dict)
        {
            foreach (var (continet, countries) in dict)
            {
                Console.WriteLine($"{continet}:");

                foreach (var (country, city) in countries)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", city)}");
                }
            }
        }
    }
}
