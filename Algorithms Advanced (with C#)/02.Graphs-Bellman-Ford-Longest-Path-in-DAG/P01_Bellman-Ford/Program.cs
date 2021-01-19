using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Bellman_Ford
{
    public class Edge
    {
        public int Source { get; set; }

        public int Destination { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static List<Edge> edges;
        private static double shortestPath;

        public static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            edges = ReadGraph(edgesCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            try
            {
                var path = FindShortestPath(nodes, source, destination);
                Console.WriteLine(string.Join(" ", path));
                Console.WriteLine(shortestPath);
            }
            catch (Exception ioe)
            {
                Console.WriteLine(ioe.Message);
                return;
            }
        }

        private static Stack<int> FindShortestPath(int nodes, int source, int destination)
        {
            var distances = new double[nodes + 1];
            Array.Fill(distances, double.PositiveInfinity);
            distances[source] = 0;

            var prev = new int[nodes + 1];
            Array.Fill(prev, -1);

            for (int i = 0; i < nodes - 1; i++)
            {
                var isUpdate = false;

                foreach (var edge in edges)
                {
                    if (double.IsPositiveInfinity(edge.Source))
                    {
                        continue;
                    }

                    var newDistance = distances[edge.Source] + edge.Weight;

                    if (newDistance < distances[edge.Destination])
                    {
                        distances[edge.Destination] = newDistance;
                        prev[edge.Destination] = edge.Source;

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
                if (double.IsPositiveInfinity(edge.Source))
                {
                    continue;
                }

                var newDistance = distances[edge.Source] + edge.Weight;

                if (newDistance < distances[edge.Destination])
                {
                    throw new InvalidOperationException($"Negative Cycle Detected");
                }
            }

            var path = ReconstructPath(prev, destination);
            shortestPath = distances[destination];

            return path;
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

        private static List<Edge> ReadGraph(int edgesCount)
        {
            var result = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var source = input[0];
                var destination = input[1];
                var weight = input[2];

                result.Add(new Edge()
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
