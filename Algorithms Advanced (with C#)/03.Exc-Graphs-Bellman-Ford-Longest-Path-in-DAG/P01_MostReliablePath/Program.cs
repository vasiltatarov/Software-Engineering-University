using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P01_MostReliablePath
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    /// <summary>
    /// We have a set of towns and some of them are connected by direct paths.
    /// Each path has a coefficient of reliability (in percentage): the chance to pass without incidents. 
    /// Your goal is to compute the most reliable path between two given nodes.
    /// Assume all percentages will be integer numbers and round the result to the second digit after the decimal separator.
    /// You can see an example input at the bottom or your own code from graph editor
    /// </summary>
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

            var distances = new double[nodesCount];
            var prev = new int[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                distances[node] = double.NegativeInfinity;
                prev[node] = -1;
            }
            distances[source] = 100;

            BFS(distances, source, destination, prev);

            var path = ReconstructPath(prev, destination);

            Console.WriteLine($"Most reliable path reliability: {distances[destination]:F2}%");
            Console.WriteLine(string.Join(" -> ", path));
        }

        private static void BFS(double[] distances, int source, int destination, int[] prev)
        {
            var queue = new OrderedBag<int>
                (Comparer<int>.Create((f, s) => distances[s].CompareTo(distances[f])));
            queue.Add(source);

            while (queue.Any())
            {
                var node = queue.RemoveFirst();

                if (node == destination)
                {
                    break;
                }

                foreach (var edge in graph[node])
                {
                    var child = edge.First == node ? edge.Second : edge.First;

                    if (double.IsNegativeInfinity(distances[child]))
                    {
                        queue.Add(child);
                    }

                    var newDistance = distances[node] * edge.Weight / 100.0;

                    if (newDistance > distances[child])
                    {
                        distances[child] = newDistance;
                        prev[child] = node;

                        queue = new OrderedBag<int>
                        (queue,
                            Comparer<int>.Create((f, s) => distances[s].CompareTo(distances[f])));
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

        private static List<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var result = new List<Edge>[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                result[i] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var data = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var first = data[0];
                var second = data[1];
                var weight = data[2];

                var edge = new Edge()
                {
                    First = first,
                    Second = second,
                    Weight = weight,
                };

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}
/*
7
10
0 3 85
0 4 88
3 1 95
3 5 98
4 5 99
4 2 14
5 1 5
5 6 90
1 6 100
2 6 95
0
6
*/
