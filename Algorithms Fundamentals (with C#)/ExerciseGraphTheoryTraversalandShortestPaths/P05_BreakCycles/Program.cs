using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_BreakCycles
{
    public class Edge
    {
        public Edge(string first, string second)
        {
            this.First = first;
            this.Second = second;
        }


        public string First { get; set; }

        public string Second { get; set; }
    }

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();
            ProcessGraph(n);

            edges = edges
                .OrderBy(x => x.First)
                .ThenBy(x => x.Second)
                .ToList();

            var removedEdges = new List<Edge>();

            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                // Ensure if current edge is already checked!
                if (removedEdges.Any(x => x.First == second && x.Second == first))
                {
                    continue;
                }

                graph[first].Remove(second);
                graph[second].Remove(first);

                if (HasPath(first, second))
                {
                    removedEdges.Add(edge);
                }
                else
                {
                    graph[first].Add(second);
                    graph[second].Add(first);
                }
            }

            PrintRemovedEdges(removedEdges);
        }

        private static bool HasPath(string source, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(source);
            var visited = new HashSet<string>{source};

            while (queue.Any())
            {
                var node = queue.Dequeue();
                var children = graph[node];

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in children)
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        private static void ProcessGraph(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var node = line[0];
                var children = line[1].Split();

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                foreach (var child in children)
                {
                    graph[node].Add(child);
                    edges.Add(new Edge(node, child));
                }
            }
        }

        private static void PrintRemovedEdges(List<Edge> removedEdges)
        {
            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var removedEdge in removedEdges)
            {
                Console.WriteLine($"{removedEdge.First} - {removedEdge.Second}");
            }
        }
    }
}
