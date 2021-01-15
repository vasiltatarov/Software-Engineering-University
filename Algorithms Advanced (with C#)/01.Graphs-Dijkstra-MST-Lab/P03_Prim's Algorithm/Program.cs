using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P03_Prim_s_Algorithm
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        private static Dictionary<int, List<Edge>> edges;
        private static HashSet<int> forest;

        static void Main(string[] args)
        {
            var e = int.Parse(Console.ReadLine());
            edges = ReadEdges(e);
            forest = new HashSet<int>();

            foreach (var node in edges.Keys)
            {
                if (!forest.Contains(node))
                {
                    Prim(node);
                }
            }
        }

        private static void Prim(int node)
        {
            forest.Add(node);
            var queue = new OrderedBag<Edge>
                (edges[node], Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            while (queue.Any())
            {
                var edge = queue.RemoveFirst();
                var nonTreeNode = GetNonTreeNode(edge.First, edge.Second);

                if (nonTreeNode == -1)
                {
                    continue;
                }

                Console.WriteLine($"{edge.First} - {edge.Second}");

                forest.Add(nonTreeNode);
                queue.AddMany(edges[nonTreeNode]);
            }
        }

        private static int GetNonTreeNode(int first, int second)
        {
            var nonTreeNode = -1;

            if (forest.Contains(first) &&
                !forest.Contains(second))
            {
                nonTreeNode = second;
            }

            if (forest.Contains(second) &&
                !forest.Contains(first))
            {
                nonTreeNode = first;
            }

            return nonTreeNode;
        }

        private static Dictionary<int, List<Edge>> ReadEdges(int e)
        {
            var result = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < e; i++)
            {
                var data = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                var first = data[0];
                var second = data[1];
                var weight = data[2];

                if (!result.ContainsKey(first))
                {
                    result.Add(first, new List<Edge>());
                }

                if (!result.ContainsKey(second))
                {
                    result.Add(second, new List<Edge>());
                }

                var edge = new Edge()
                {
                    First = first,
                    Second = second,
                    Weight = weight
                };
                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}
