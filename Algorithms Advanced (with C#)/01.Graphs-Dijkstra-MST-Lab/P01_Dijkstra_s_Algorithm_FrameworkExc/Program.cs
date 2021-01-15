using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P01_Dijkstra_s_Algorithm_FrameworkExc
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static Dictionary<int, List<Edge>> edges;

        static void Main(string[] args)
        {
            var e = int.Parse(Console.ReadLine());

            edges = FindConnections(e);

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            var maxNode = edges.Keys.Max();

            var distances = FindDistances(maxNode);
            distances[startNode] = 0;

            var prev = new int[maxNode + 1];
            prev[startNode] = -1;

            BFS(distances, startNode, endNode, prev);

            if (distances[endNode] == int.MaxValue)
            {
                Console.WriteLine($"There is no such path.");
                return;
            }

            var path = FindPath(endNode, prev);

            PrintResult(distances, endNode, path);
        }

        private static void PrintResult(int[] distances, int endNode, Stack<int> path)
        {
            Console.WriteLine(distances[endNode]);
            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<int> FindPath(int endNode, int[] prev)
        {
            var path = new Stack<int>();
            var node = endNode;

            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            return path;
        }

        private static void BFS(int[] distances, int startNode, int endNode, int[] prev)
        {
            var queue = new OrderedBag<int>
                (Comparer<int>.Create((f, s) => distances[f] - distances[s]));
            queue.Add(startNode);

            while (queue.Any())
            {
                var minNode = queue.RemoveFirst();
                var children = edges[minNode];

                if (minNode == endNode)
                {
                    break;
                }

                foreach (var child in children)
                {
                    var childNode = child.From == minNode
                        ? child.To
                        : child.From;

                    if (distances[childNode] == int.MaxValue)
                    {
                        queue.Add(childNode);
                    }

                    var newDistances = child.Weight + distances[minNode];

                    if (newDistances < distances[childNode])
                    {
                        distances[childNode] = newDistances;
                        prev[childNode] = minNode;

                        queue = new OrderedBag<int>
                            (queue, Comparer<int>.Create((f, s) => distances[f] - distances[s]));
                    }
                }
            }
        }

        private static int[] FindDistances(int maxNode)
        {
            var distances = new int[maxNode + 1];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }

            return distances;
        }

        private static Dictionary<int, List<Edge>> FindConnections(int e)
        {
            var result = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < e; i++)
            {
                var input = Console.ReadLine().Split(new string[]{", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var from = input[0];
                var to = input[1];
                var weight = input[2];

                if (!result.ContainsKey(from))
                {
                    result.Add(from, new List<Edge>());
                }

                if (!result.ContainsKey(to))
                {
                    result.Add(to, new List<Edge>());
                }

                var edge = new Edge()
                {
                    From = from,
                    To = to,
                    Weight = weight
                };

                result[from].Add(edge);
                result[to].Add(edge);
            }

            return result;
        }
    }
}
