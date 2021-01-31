using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_ElectricalSubstationNetwork
{
    class Program
    {
        private static List<int>[] graph;
        private static List<int>[] reverseGraph;

        /// <summary>
        /// Print all connected electrical substations in a town using the existing network.
        /// The substations are represented as vertices and the connections are represented as edges.
        /// </summary>
        static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var linesCount = int.Parse(Console.ReadLine());

            (graph, reverseGraph) = ReadGraph(nodesCount, linesCount);

            var sorted = TopologicalSorting();

            var visited = new bool[graph.Length];

            while (sorted.Any())
            {
                var node = sorted.Pop();

                if (visited[node])
                {
                    continue;
                }

                var components = new Stack<int>();

                DFS(reverseGraph, node, visited, components);

                Console.WriteLine(string.Join(", ", components));
            }
        }

        private static Stack<int> TopologicalSorting()
        {
            var result = new Stack<int>();
            var visited = new bool[graph.Length];

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(graph, node, visited, result);
            }

            return result;
        }

        private static void DFS(List<int>[] source, int node, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in source[node])
            {
                DFS(source, child, visited, result);
            }

            result.Push(node);
        }

        private static (List<int>[] graph, List<int>[] reverseGraph) ReadGraph(int nodesCount, int linesCount)
        {
            var origin = new List<int>[nodesCount];
            var reversed = new List<int>[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                origin[node] = new List<int>();
                reversed[node] = new List<int>();
            }

            for (int i = 0; i < linesCount; i++)
            {
                var data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                var node = data[0];

                for (int j = 1; j < data.Length; j++)
                {
                    var child = data[j];

                    origin[node].Add(child);
                    reversed[child].Add(node);
                }
            }

            return (origin, reversed);
        }
    }
}