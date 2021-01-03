using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_PathFinder
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
            var pathCount = int.Parse(Console.ReadLine());

            FindPaths(pathCount);
        }

        private static void FindPaths(int pathCount)
        {
            for (int i = 0; i < pathCount; i++)
            {
                var lines = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var isHavePath = false;

                for (int j = 0; j < lines.Count - 1; j++)
                {
                    if (!graph.ContainsKey(lines[j]))
                    {
                        isHavePath = true;
                        break;
                    }

                    if (!graph[lines[j]].Contains(lines[j + 1]))
                    {
                        isHavePath = true;
                        break;
                    }
                }

                if (isHavePath)
                {
                    Console.WriteLine("no");
                }
                else
                {
                    Console.WriteLine("yes");
                }
            }
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            var result = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    result.Add(i, new List<int>());
                    continue;
                }

                var edges = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                result.Add(i, edges);
            }

            return result;
        }
    }
}
