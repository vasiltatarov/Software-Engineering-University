using System;

namespace P07_MinimumEditDistance
{
    class Program
    {
        private static int replaceCost;
        private static int insertCost;
        private static int deleteCost;

        static void Main()
        {
            replaceCost = int.Parse(Console.ReadLine());
            insertCost = int.Parse(Console.ReadLine());
            deleteCost = int.Parse(Console.ReadLine());
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = new int[str1.Length + 1, str2.Length + 1];

            var editCount = GetMinimumEditDistance(table, str1, str2);

            Console.WriteLine($"Minimum edit distance: {editCount}");
        }

        private static int GetMinimumEditDistance(int[,] table, string str1, string str2)
        {
            //Fill first row
            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r * deleteCost;
            }

            //Fill first col
            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[0, c] = c * insertCost;
            }

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1];
                    }
                    else
                    {
                        var replace = table[r - 1, c - 1] + replaceCost;
                        var insert = table[r - 1, c] + deleteCost;
                        var delete = table[r, c - 1] + insertCost;

                        table[r, c] = Math.Min(Math.Min(replace, insert), delete);
                    }
                }
            }

            return table[str1.Length, str2.Length];
        }
    }
}