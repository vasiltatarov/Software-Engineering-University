using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Undefined
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    /// <summary>
    /// Your task is to find the shortest path in a graph from S vertex to D vertex.
    /// However, edges might have negative weights and for this reason, you should be cautious for negative cycles.
    /// •	If there is a negative cycle you should print "Undefined".
    /// </summary>
    public class Program
    {
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            edges = ReadEdges(edgesCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var distances = new double[nodesCount + 1];
            var prev = new int[nodesCount + 1];

            for (int node = 0; node <= nodesCount; node++)
            {
                distances[node] = double.PositiveInfinity;
                prev[node] = -1;
            }
            distances[source] = 0;

            try
            {
                FindShortestPath(nodesCount, distances, prev);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            var path = ReconstructPath(prev, destination);

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distances[destination]);
        }

        private static void FindShortestPath(int nodesCount, double[] distances, int[] prev)
        {
            for (int i = 0; i < nodesCount - 1; i++)
            {
                var isUpdate = false;

                foreach (var edge in edges)
                {
                    if (double.IsPositiveInfinity(edge.From))
                    {
                        continue;
                    }

                    var newDistance = distances[edge.From] + edge.Weight;
                    if (newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        prev[edge.To] = edge.From;

                        isUpdate = true;
                    }
                }

                if (!isUpdate)
                {
                    break;
                }
            }

            foreach (var edge in edges)
            {
                var newDistance = distances[edge.From] + edge.Weight;
                if (newDistance < distances[edge.To])
                {
                    distances[edge.To] = newDistance;
                    prev[edge.To] = edge.From;

                    throw new InvalidOperationException($"Undefined");
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

        private static List<Edge> ReadEdges(int edgesCount)
        {
            var result = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var first = input[0];
                var second = input[1];
                var weight = input[2];

                result.Add(new Edge()
                {
                    From = first,
                    To = second,
                    Weight = weight,
                });
            }

            return result;
        }
    }
}
