using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_ConnectedAreasInAMatrix
{
    public class Area
    {
        public Area(int row, int col, int size)
        {
            Row = row;
            Col = col;
            Size = size;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }

    class StartUp
    {
        private static char[,] matrix;
        private static bool[,] visited;

        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            visited = new bool[rows, cols];
            var areas = new List<Area>();

            ReadMatrixData();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == '*')
                    {
                        continue;
                    }

                    if (visited[r, c])
                    {
                        continue;
                    }

                    var size = ConnectedArea(r, c);
                    var area = new Area(r, c, size);

                    areas.Add(area);
                }
            }

            var orderedAreas = areas
                .OrderByDescending(x => x.Size)
                .ThenBy(x => x.Row)
                .ThenBy(x => x.Col)
                .ToList();

            PrintAreas(orderedAreas);
        }

        private static void PrintAreas(List<Area> areas)
        {
            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i+1} at ({areas[i].Row}, {areas[i].Col}), size: {areas[i].Size}");
            }
        }

        private static int ConnectedArea(int row, int col)
        {
            if (IsOutside(row, col))
            {
                return 0;
            }

            if (matrix[row, col] == '*')
            {
                return 0;
            }

            if (visited[row, col])
            {
                return 0;
            }

            visited[row, col] = true;

            return 1 +
                   ConnectedArea(row - 1, col) +
                   ConnectedArea(row + 1, col) +
                   ConnectedArea(row, col - 1) +
                   ConnectedArea(row, col + 1);
        }

        private static bool IsOutside(int row, int col)
            => row < 0 ||
               col < 0 ||
               row >= matrix.GetLength(0) ||
               col >= matrix.GetLength(1);


        private static void ReadMatrixData()
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var data = Console.ReadLine();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = data[c];
                }
            }
        }
    }
}
