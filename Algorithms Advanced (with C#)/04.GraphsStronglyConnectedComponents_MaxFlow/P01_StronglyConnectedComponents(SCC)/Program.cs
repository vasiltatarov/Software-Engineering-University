using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_StronglyConnectedComponents_SCC_
{
    class Program
    {
        private static List<int>[] graph;
        private static List<int>[] reversedGraph;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var linesCount = int.Parse(Console.ReadLine());

            (graph, reversedGraph) = ReadGraphs(nodesCount, linesCount);

            var sorted = TopologicalSorting();

            FindStronglyConnectedComponents(sorted);
        }

        private static void FindStronglyConnectedComponents(Stack<int> sorted)
        {
            var visited = new bool[graph.Length];

            Console.WriteLine($"Strongly Connected Components:");

            foreach (var node in sorted)
            {
                if (visited[node])
                {
                    continue;
                }

                var components = new Stack<int>();

                DFS(node, reversedGraph, visited, components);

                Console.WriteLine($"{{{string.Join(", ", components)}}}");
            }
        }

        private static Stack<int> TopologicalSorting()
        {
            var sorted = new Stack<int>();
            var visited = new bool[graph.Length];

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, visited, sorted);
            }

            return sorted;
        }

        private static void DFS(int node, List<int>[] source, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in source[node])
            {
                DFS(child, source, visited, result);
            }

            result.Push(node);
        }

        private static (List<int>[] graph, List<int>[] reversedGraph) ReadGraphs(int nodesCount, int linesCount)
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
