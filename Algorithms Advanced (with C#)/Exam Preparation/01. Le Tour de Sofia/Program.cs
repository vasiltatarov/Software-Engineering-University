using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.Le_Tour_de_Sofia
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Distance { get; set; }
    }

    class Program
    {
        private static List<Edge>[] graph;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());
            var startNode = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);

            var distances = new double[nodesCount];
            for (int node = 0; node < distances.Length; node++)
            {
                distances[node] = double.PositiveInfinity;
            }

            var queue = new OrderedBag<int>
                (Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));

            foreach (var edge in graph[startNode])
            {
                distances[edge.To] = edge.Distance;
                queue.Add(edge.To);
            }

            var visited = new HashSet<int> { startNode };

            while (queue.Any())
            {
                var node = queue.RemoveFirst();
                visited.Add(node);

                if (node == startNode)
                {
                    break;
                }

                foreach (var edge in graph[node])
                {
                    var child = edge.To;

                    if (double.IsPositiveInfinity(distances[child]))
                    {
                        queue.Add(child);
                    }

                    var newDistance = distances[node] + edge.Distance;
                    if (newDistance < distances[child])
                    {
                        distances[child] = newDistance;

                        queue = new OrderedBag<int>
                            (queue, Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
                    }
                }
            }

            if (double.IsPositiveInfinity(distances[startNode]))
            {
                Console.WriteLine(visited.Count);
            }
            else
            {
                Console.WriteLine(distances[startNode]);
            }
        }

        private static List<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<Edge>[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                result[node] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var from = data[0];
                var to = data[1];
                var distance = data[2];

                var edge = new Edge()
                {
                    From = from,
                    To = to,
                    Distance = distance,
                };

                result[from].Add(edge);
            }

            return result;
        }
    }
}
