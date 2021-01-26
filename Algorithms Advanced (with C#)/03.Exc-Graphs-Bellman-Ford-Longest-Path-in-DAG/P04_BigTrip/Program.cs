using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_BigTrip
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        private static List<Edge>[] graph;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distances = new double[graph.Length];
            var prev = new int[graph.Length];

            for (int node = 0; node < nodesCount; node++)
            {
                distances[node] = double.NegativeInfinity;
                prev[node] = -1;
            }
            distances[source] = 0;

            var sortedNodes = TopologicalSort();

            FindLongestPath(sortedNodes, distances, prev);

            var path = ReconstructPath(prev, destination);

            Console.WriteLine(distances[destination]);
            Console.WriteLine(string.Join(" ", path));
        }

        private static void FindLongestPath(Stack<int> sortedNodes, double[] distances, int[] prev)
        {
            while (sortedNodes.Any())
            {
                var node = sortedNodes.Pop();

                foreach (var edge in graph[node])
                {
                    var newDistance = distances[node] + edge.Weight;
                    if (newDistance > distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        prev[edge.To] = node;
                    }
                }
            }
        }

        private static Stack<int> ReconstructPath(int[] prev, int node)
        {
            var path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            return path;
        }

        private static Stack<int> TopologicalSort()
        {
            var sortedNodes = new Stack<int>();
            var visisted = new bool[graph.Length];

            for (int node = 1; node < graph.Length; node++)
            {
                DFS(node, visisted, sortedNodes);
            }

            return sortedNodes;
        }

        private static void DFS(int node, bool[] visisted, Stack<int> sortedNodes)
        {
            if (visisted[node])
            {
                return;
            }

            visisted[node] = true;

            foreach (var edge in graph[node])
            {
                DFS(edge.To, visisted, sortedNodes);
            }

            sortedNodes.Push(node);
        }

        private static List<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<Edge>[nodesCount + 1];

            for (int i = 0; i < nodesCount + 1; i++)
            {
                result[i] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var from = input[0];
                var to = input[1];
                var weight = input[2];

                var edge = new Edge()
                {
                    From = from,
                    To = to,
                    Weight = weight,
                };

                result[from].Add(edge);
            }

            return result;
        }
    }
}
