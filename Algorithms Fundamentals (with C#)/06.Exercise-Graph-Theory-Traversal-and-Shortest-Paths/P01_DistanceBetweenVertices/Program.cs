using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_DistanceBetweenVertices
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static List<int[]> destinations;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var p = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
            destinations = ReadDestinations(p);

            foreach (var node in destinations)
            {
                var source = node[0];
                var destination = node[1];

                var steps = GetShortestPath(source, destination);

                Console.WriteLine($"{{{source}, {destination}}} -> {steps}");
            }
        }

        private static int GetShortestPath(int source, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(source);

            var steps = new Dictionary<int, int> {{source, 0}};

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return steps[node];
                }

                if (graph[node] == null)
                {
                    continue;
                }

                foreach (var child in graph[node])
                {
                    if (steps.ContainsKey(child))
                    {
                        continue;
                    }

                    steps[child] = steps[node] + 1;
                    queue.Enqueue(child);
                }
            }

            return -1;
        }

        private static List<int[]> ReadDestinations(int p)
        {
            var result = new List<int[]>();

            for (int i = 0; i < p; i++)
            {
                var pairs = Console.ReadLine().Split("-").Select(int.Parse).ToArray();
                result.Add(pairs);
            }

            return result;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            var resultGraph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new string[] { ":", " " }, StringSplitOptions.RemoveEmptyEntries);
                var key = int.Parse(line[0]);

                if (!resultGraph.ContainsKey(key))
                {
                    resultGraph.Add(key, new List<int>());
                }

                var edges = line.Skip(1).Select(int.Parse).ToList();
                resultGraph[key] = edges;
            }

            return resultGraph;
        }
    }
}
