using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_ShortestPath
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parents;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            ReadGraph(n, edges);
            visited = new bool[graph.Length];
            parents = new int[graph.Length];
            Array.Fill(parents, -1);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());
            
            Bfs(source, destination);
        }

        private static void Bfs(int startNode, int destination)
        {
            if (visited[startNode])
            {
                return;
            }

            var queue = new Queue<int>();

            queue.Enqueue(startNode);
            visited[startNode] = true;

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = ReconstructGraph(destination);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));

                    return;
                }

                if (graph[node] == null)
                {
                    continue;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parents[child] = node;
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }
        }

        private static Stack<int> ReconstructGraph(int destination)
        {
            var result = new Stack<int>();
            var index = destination;

            while (index > -1)
            {
                result.Push(index);
                index = parents[index];
            }

            return result;
        }

        private static void ReadGraph(int n, int edges)
        {
            graph = new List<int>[n + 1];

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var from = edge[0];
                var to = edge[1];

                if (graph[from] == null)
                {
                    graph[from] = new List<int>();
                }

                graph[from].Add(to);
            }
        }
    }
}
