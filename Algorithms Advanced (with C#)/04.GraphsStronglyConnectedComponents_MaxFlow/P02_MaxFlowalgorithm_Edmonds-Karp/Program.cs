using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_MaxFlowalgorithm_Edmonds_Karp
{
    class Program
    {
        private static int[,] graph;
        private static int[] parents;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());
            
            parents = new int[nodesCount];
            Array.Fill(parents, -1);

            var maxFlow = 0;
            while (BFS(source, parents, destination))
            {
                //Find min flow
                var currentFlow = GetCurrentFlow(source, destination);

                maxFlow += currentFlow;

                ApplyCurrentFlow(source, destination, currentFlow);
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void ApplyCurrentFlow(int source, int destination, int currentFlow)
        {
            var node = destination;

            while (node != source)
            {
                var parent = parents[node];

                graph[parent, node] -= currentFlow;

                node = parent;
            }
        }

        private static int GetCurrentFlow(int source, int destination)
        {
            var node = destination;
            var minFlow = int.MaxValue;

            while (node != source)
            {
                var parent = parents[node];
                var flow = graph[parent, node];

                if (flow < minFlow)
                {
                    minFlow = flow;
                }

                node = parent;
            }

            return minFlow;
        }

        private static bool BFS(int source, int[] parents, int destination)
        {
            var visited = new bool[graph.GetLength(0)];
            var queue = new Queue<int>();

            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Any())
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(0); child++)
                {
                    if (!visited[child] &&
                        graph[node, child] > 0)
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parents[child] = node;
                    }
                }
            }

            return visited[destination];
        }

        private static int[,] ReadGraph(int nodesCount)
        {
            var result = new int[nodesCount, nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                var data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int child = 0; child < data.Length; child++)
                {
                    result[node, child] = data[child];
                }
            }

            return result;
        }
    }
}
