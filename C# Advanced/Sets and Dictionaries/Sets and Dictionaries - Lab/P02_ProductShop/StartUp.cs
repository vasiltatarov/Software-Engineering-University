using System;
using System.Collections.Generic;

namespace P03_ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var dict = new SortedDictionary<string, Dictionary<string, double>>();
            ReadData(dict);
            PrintData(dict);
        }

        public static void ReadData(SortedDictionary<string, Dictionary<string, double>> dict)
        {
            while (true)
            {
                var stockArgs = Console.ReadLine();

                if (stockArgs == "Revision")
                {
                    break;
                }

                var args = stockArgs.Split(", ");
                var shop = args[0];
                var product = args[1];
                var price = double.Parse(args[2]);

                if (!dict.ContainsKey(shop))
                {
                    dict.Add(shop, new Dictionary<string, double>());
                }

                if (!dict[shop].ContainsKey(product))
                {
                    dict[shop].Add(product, price);
                }
            }
        }

        public static void PrintData(SortedDictionary<string, Dictionary<string, double>> dict)
        {
            foreach (var (shop, shopArgs) in dict)
            {
                Console.WriteLine($"{shop}->");

                foreach (var (product, price) in shopArgs)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
