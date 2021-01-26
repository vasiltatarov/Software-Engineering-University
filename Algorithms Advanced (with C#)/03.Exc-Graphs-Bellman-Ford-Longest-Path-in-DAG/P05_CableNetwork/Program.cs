using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P05_CableNetwork
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static List<Edge>[] graph;
        private static HashSet<int> spaningTree;

        static void Main(string[] args)
        {
            var budget = int.Parse(Console.ReadLine());
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            spaningTree = new HashSet<int>();
            graph = ReadGraph(nodesCount, edgesCount);

            var usedBudget = Prim(budget);

            Console.WriteLine($"Budget used: {usedBudget}");
        }

        private static int Prim(int budget)
        {
            var usedBudget = 0;

            var queue = new OrderedBag<Edge>
                (Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            foreach (var node in spaningTree)
            {
                queue.AddMany(graph[node]);
            }

            while (queue.Any())
            {
                var edge = queue.RemoveFirst();
                var nonTreeNode = GetNonTreeNode(edge);

                if (nonTreeNode == -1)
                {
                    continue;
                }

                if (edge.Weight > budget)
                {
                    break;
                }

                usedBudget += edge.Weight;
                budget -= edge.Weight;

                spaningTree.Add(nonTreeNode);
                queue.AddMany(graph[nonTreeNode]);
            }

            return usedBudget;
        }

        private static int GetNonTreeNode(Edge edge)
        {
            var nonTreeNode = -1;
            if (spaningTree.Contains(edge.First) &&
                !spaningTree.Contains(edge.Second))
            {
                nonTreeNode = edge.Second;
            }
            else if (spaningTree.Contains(edge.Second) &&
                     !spaningTree.Contains(edge.First))
            {
                nonTreeNode = edge.First;
            }

            return nonTreeNode;
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
                var input = Console.ReadLine().Split();
                var first = int.Parse(input[0]);
                var second = int.Parse(input[1]);
                var weight = int.Parse(input[2]);

                if (input.Length == 4)
                {
                    spaningTree.Add(first);
                    spaningTree.Add(second);
                }

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
