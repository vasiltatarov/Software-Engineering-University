using System;
using System.Collections.Generic;

namespace P02_Knapsack
{
    public class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }
    }

    class Program
    {
        private static List<Item> items;

        static void Main()
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            items = ReadItems();

            var table = new int[items.Count + 1, maxCapacity + 1];

            for (int item = 1; item < table.GetLength(0); item++)
            {
                var currentItem = items[item - 1];

                for (int capacity = 1; capacity < table.GetLength(1); capacity++)
                {
                    if (capacity < currentItem.Weight)
                    {
                        table[item, capacity] = table[item - 1, capacity];
                    }
                    else
                    {
                        table[item, capacity] = Math.Max(table[item - 1, capacity],
                            table[item - 1, capacity - currentItem.Weight] + currentItem.Value);
                    }
                }
            }

            var selectedItems = new SortedSet<string>();
            var totalWeight = 0;
            var totalValue = 0;

            var row = table.GetLength(0) - 1;
            var col = table.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    var selectedItem = items[row - 1];

                    selectedItems.Add(selectedItem.Name);
                    totalWeight += selectedItem.Weight;
                    totalValue += selectedItem.Value;

                    col -= selectedItem.Weight;
                }

                row -= 1;
            }

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {totalValue}");

            foreach (var item in selectedItems)
            {
                Console.WriteLine(item);
            }
        }

        private static List<Item> ReadItems()
        {
            var result = new List<Item>();

            while (true)
            {
                var data = Console.ReadLine().Split();

                if (data[0] == "end")
                {
                    break;
                }

                var name = data[0];
                var weight = int.Parse(data[1]);
                var value = int.Parse(data[2]);

                result.Add(new Item()
                {
                    Name = name,
                    Weight = weight,
                    Value = value,
                });
            }

            return result;
        }
    }
}
