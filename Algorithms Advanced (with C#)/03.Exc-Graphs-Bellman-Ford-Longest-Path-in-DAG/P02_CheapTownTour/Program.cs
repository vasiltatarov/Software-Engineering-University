using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_CheapTownTour
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    /// <summary>
    /// Your task is to find the shortest path in a graph from S vertex to D vertex.
    /// However, edges might have negative weights and for this reason, you should be cautious for negative cycles.
    /// You will be given the amount of the cities on the first line,
    /// then the amount of the roads (n) and on the next n lines you will receive which tows the road connects and the cost to use it. 
    ///Assume you can start from any town and your target is to visit every one of them with the minimum cost.
    /// </summary>
    class Program
    {
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            edges = ReadEdges(edgesCount);
            var sortedEdges = edges.OrderBy(x => x.Weight).ToList();

            var root = InitializeRoot(nodesCount);

            var totalCost = FindShortestPathInGraph(sortedEdges, root);

            Console.WriteLine($"Total cost: {totalCost}");
        }

        private static int FindShortestPathInGraph(List<Edge> sortedEdges, int[] root)
        {
            var totalCost = 0;

            foreach (var edge in sortedEdges)
            {
                var firstRoot = GetRoot(edge.First, root);
                var secondRoot = GetRoot(edge.Second, root);

                if (firstRoot != secondRoot)
                {
                    root[firstRoot] = secondRoot;
                    totalCost += edge.Weight;
                }
            }

            return totalCost;
        }

        private static int[] InitializeRoot(int nodesCount)
        {
            var root = new int[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                root[node] = node;
            }

            return root;
        }

        private static int GetRoot(int node, int[] roots)
        {
            while (node != roots[node])
            {
                node = roots[node];
            }

            return node;
        }

        private static List<Edge> ReadEdges(int edgesCount)
        {
            var result = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                var data = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();
                var first = data[0];
                var second = data[1];
                var weight = data[2];

                result.Add(new Edge()
                {
                    First = first,
                    Second = second,
                    Weight = weight,
                });
            }

            return result;
        }
    }
}
