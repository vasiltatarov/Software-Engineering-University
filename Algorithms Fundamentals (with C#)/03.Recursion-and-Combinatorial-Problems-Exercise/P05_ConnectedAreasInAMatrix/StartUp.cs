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
        private static List<Area> areas;

        static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(row, col);
            visited = new bool[row, col];
            areas = new List<Area>();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (IsWall(r, c) ||
                        visited[r, c])
                    {
                        continue;
                    }

                    var size = FindConnectedSize(r, c);
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
                Console.WriteLine($"Area #{i + 1} at ({areas[i].Row}, {areas[i].Col}), size: {areas[i].Size}");
            }
        }

        private static int FindConnectedSize(int row, int col)
        {
            if (IsOutside(row, col) ||
                IsWall(row, col) ||
                visited[row, col])
            {
                return 0;
            }

            visited[row, col] = true;

            return 1 +
                    FindConnectedSize(row - 1, col) +
                    FindConnectedSize(row + 1, col) +
                    FindConnectedSize(row, col - 1) +
                    FindConnectedSize(row, col + 1);
        }

        private static bool IsOutside(int row, int col)
            => row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);

        private static bool IsWall(int row, int col)
            => matrix[row, col] == '*';

        private static char[,] ReadMatrix(int row, int col)
        {
            var result = new char[row, col];

            for (int r = 0; r < row; r++)
            {
                var data = Console.ReadLine();

                for (int c = 0; c < col; c++)
                {
                    result[r, c] = data[c];
                }
            }

            return result;
        }
    }
}
