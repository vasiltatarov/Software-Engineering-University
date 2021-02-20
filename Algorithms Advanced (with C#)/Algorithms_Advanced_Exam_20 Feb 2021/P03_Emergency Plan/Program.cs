using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P03_Emergency_Plan
{
    public class Edge
    {
        public Edge(int node, int time)
        {
            this.Node = node;
            this.Time = time;
        }

        public int Node { get; set; }

        public int Time { get; set; }
    }

    public class Program
    {
        private static int nodesCount;
        private static int[] exitPoints;
        private static List<List<Edge>> graph;
        private static int time;
        private static int connections;
        private static bool[] exit;

        public static void Main(string[] args)
        {
            nodesCount = int.Parse(Console.ReadLine());
            exitPoints = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            connections = int.Parse(Console.ReadLine());

            graph = ReadGraph();

            time = ConvertTime(Console.ReadLine());

            for (int node = 0; node < nodesCount; node++)
            {
                if (!exit[node])
                {
                    var minTime = FindShortestPath(node);

                    if (minTime == -1)
                    {
                        Console.WriteLine($"Unreachable {node} (N/A)");
                    }
                    else
                    {
                        Console.WriteLine($"{(minTime <= time ? "Safe" : "Unsafe")} {node} " +
                            $"({minTime / 3600:D2}:{minTime / 60 % 60:D2}:{minTime % 60:D2})");
                    }
                }
            }
        }

        private static List<List<Edge>> ReadGraph()
        {
            var result = new List<List<Edge>>();

            exit = new bool[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                exit[node] = false;
            }

            foreach (int node in exitPoints)
            {
                exit[node] = true;
            }

            for (int i = 0; i < nodesCount; i++)
            {
                result.Add(new List<Edge>());
            }

            for (int i = 0; i < connections; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var first = int.Parse(input[0]);
                var second = int.Parse(input[1]);
                var duration = ConvertTime(input[2]);

                result[first].Add(new Edge(second, duration));
                result[second].Add(new Edge(first, duration));
            }

            return result;
        }

        private static int FindShortestPath(int startNode)
        {
            var visited = new bool[nodesCount];
            var distances = new int[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                visited[node] = false;
                distances[node] = int.MaxValue;
            }

            OrderedBag<int> queue = new OrderedBag<int>
                (Comparer<int>.Create((f, s) => distances[f] - distances[s]));

            queue.Add(startNode);
            distances[startNode] = 0;

            while (queue.Any())
            {
                var node = queue.RemoveFirst();
                visited[node] = true;

                if (exit[node])
                {
                    return distances[node];
                }

                foreach (var edge in graph[node])
                {
                    if (!visited[edge.Node])
                    {
                        if (distances[edge.Node] > distances[node] + edge.Time)
                        {
                            distances[edge.Node] = distances[node] + edge.Time;
                        }

                        queue.Add(edge.Node);
                    }
                }
            }

            return -1;
        }

        private static int ConvertTime(string data)
        {
            var duration = data
                .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return duration[0] * 60 + duration[1];
        }
    }
}