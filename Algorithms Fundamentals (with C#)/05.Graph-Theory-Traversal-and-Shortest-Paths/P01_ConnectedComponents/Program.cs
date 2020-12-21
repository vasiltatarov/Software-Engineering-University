using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_ConnectedComponents
{
    class Program
    {
        private static bool[] visited;
        private static List<int>[] graph;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new bool[n];

            ReadGraphValues(n);

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                var components = new List<int>();

                DFS(node, components);

                Console.WriteLine($"Connected component: {string.Join(" ", components)}");
            }
        }

        private static void DFS(int node, List<int> components)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, components);
            }

            components.Add(node);
        }

        private static void ReadGraphValues(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    graph[i] = line.Split().Select(int.Parse).ToList();
                }
            }
        }
    }
}
