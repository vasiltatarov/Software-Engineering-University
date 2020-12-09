using System;
using System.Collections.Generic;

namespace P02_AreasInMatrix
{
    public class Node
    {
        public Node(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }

    class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            matrix = ReadMatrix(n, m);
            visited = new bool[n, m];
            areas = new SortedDictionary<char, int>();
            var countAreas = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }

                    Dfs(row, col);

                    var key = matrix[row, col];
                    countAreas++;

                    if (!areas.ContainsKey(key))
                    {
                        areas.Add(key, 0);
                    }

                    areas[key]++;
                }
            }

            PrintAreas(countAreas);
        }

        private static void PrintAreas(int countAreas)
        {
            Console.WriteLine($"Areas: {countAreas}");

            foreach (var (area, times) in areas)
            {
                Console.WriteLine($"Letter '{area}' -> {times}");
            }
        }

        private static void Dfs(int row, int col)
        {
            visited[row, col] = true;

            var children = GetChildren(row, col);

            foreach (var child in children)
            {
                Dfs(child.Row, child.Col);
            }
        }

        private static List<Node> GetChildren(int row, int col)
        {
            var nodes = new List<Node>();

            //row + 1, col
            if (IsInside(row + 1, col) &&
                IsChild(row, col, row + 1, col) &&
                !visited[row + 1, col])
            {
                nodes.Add(new Node(row + 1, col));
            }

            //row - 1, col
            if (IsInside(row - 1, col) &&
                IsChild(row, col, row - 1, col) &&
                !visited[row - 1, col])
            {
                nodes.Add(new Node(row - 1, col));
            }

            //row, col + 1
            if (IsInside(row, col + 1) &&
                IsChild(row, col, row, col + 1) &&
                !visited[row, col + 1])
            {
                nodes.Add(new Node(row, col + 1));
            }

            //row, col - 1
            if (IsInside(row, col - 1) &&
                IsChild(row, col, row, col - 1) &&
                !visited[row, col - 1])
            {
                nodes.Add(new Node(row, col - 1));
            }

            return nodes;
        }

        private static bool IsChild(int parentRow, int parentCol, int childRow, int childCol)
            => matrix[parentRow, parentCol] == matrix[childRow, childCol];

        private static bool IsInside(int row, int col)
            => row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var result = new char[rows, cols];

            for (int row = 0; row < result.GetLength(0); row++)
            {
                var values = Console.ReadLine();

                for (int col = 0; col < result.GetLength(1); col++)
                {
                    result[row, col] = values[col];
                }
            }

            return result;
        }
    }
}
