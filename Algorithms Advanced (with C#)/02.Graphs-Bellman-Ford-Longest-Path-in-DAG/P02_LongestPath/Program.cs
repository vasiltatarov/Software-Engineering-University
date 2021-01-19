using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_LongestPath
{
    public class Edge
    {
        public int Source { get; set; }

        public int Destination { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        private static List<Edge>[] graph;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodes, edgesCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var path = GetLongestPath(source, destination);

            Console.WriteLine(string.Join(" ", path));
        }

        /// <summary>
        /// If you wanna to get shortest path with this algorithm
        /// Step 1 - Array.Fill(distances, double.PositiveInfinity);
        /// Step 2 - if (newDistance < distances[edge.Destination])
        /// </summary>
        private static Stack<int> GetLongestPath(int source, int destination)
        {
            var sortedNodes = TopologicalSorting();

            var distances = new double[graph.Length];
            Array.Fill(distances, double.NegativeInfinity);
            distances[source] = 0;

            var prev = new int[graph.Length];
            Array.Fill(prev, -1);

            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph[node])
                {
                    var newDistance = distances[node] + edge.Weight;
                    if (newDistance > distances[edge.Destination])
                    {
                        distances[edge.Destination] = newDistance;
                        prev[edge.Destination] = node;
                    }
                }
            }

            Console.WriteLine(distances[destination]);

            var path = ReconstructPath(prev, destination);

            return path;
        }

        private static Stack<int> ReconstructPath(int[] prev, int node)
        {
            var path = new Stack<int>();

            while (node != -1)
            {
                if (path.Contains(node))
                {
                    return path;
                }

                path.Push(node);
                node = prev[node];
            }

            return path;
        }

        private static Stack<int> TopologicalSorting()
        {
            var visited = new bool[graph.Length];
            var sorted = new Stack<int>();

            for (int node = 1; node < graph.Length; node++)
            {
                DFS(node, visited, sorted);
            }

            return sorted;
        }

        private static void DFS(int node, bool[] visited, Stack<int> sorted)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var edge in graph[node])
            {
                DFS(edge.Destination, visited, sorted);
            }

            sorted.Push(node);
        }

        private static List<Edge>[] ReadGraph(int nodes, int edgesCount)
        {
            var result = new List<Edge>[nodes + 1];

            for (int node = 0; node < result.Length; node++)
            {
                result[node] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var source = input[0];
                var destination = input[1];
                var weight = input[2];

                result[source].Add(new Edge()
                {
                    Source = source,
                    Destination = destination,
                    Weight = weight,
                });
            }

            return result;
        }
    }
}
