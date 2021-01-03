using System;
using System.Collections.Generic;

namespace P01_TBC
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

    class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static List<Area> areas;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            ReadMatrix(rows, cols);
            visited = new bool[rows, cols];
            areas = new List<Area>();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (InNotTunnel(r, c) ||
                        visited[r, c])
                    {
                        continue;
                    }

                    var size = FindConnectedSize(r, c);
                    var area = new Area(r, c, size);
                    areas.Add(area);
                }
            }

            Console.WriteLine(areas.Count);
        }

        private static int FindConnectedSize(int row, int col)
        {
            if (IsOutside(row, col) ||
                InNotTunnel(row, col) ||
                visited[row, col])
            {
                return 0;
            }

            visited[row, col] = true;

            return 1 +
                   FindConnectedSize(row - 1, col) +
                   FindConnectedSize(row + 1, col) +
                   FindConnectedSize(row, col - 1) +
                   FindConnectedSize(row, col + 1) +
                   FindConnectedSize(row + 1, col + 1) +
                   FindConnectedSize(row - 1, col - 1) +
                   FindConnectedSize(row - 1, col + 1) +
                   FindConnectedSize(row + 1, col - 1);
        }

        private static bool IsOutside(int row, int col)
            => row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);

        private static bool InNotTunnel(int row, int col)
            => matrix[row, col] == 'd';

        private static void ReadMatrix(int rows, int cols)
        {
            matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var lines = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = lines[col];
                }
            }
        }
    }
}
