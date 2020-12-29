using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_RoadReconstruction
{
    /// <summary>
    /// This is the task from Exercise: Graph Theory Traversal and Shortest Paths
    /// </summary>

    public class Street
    {
        public Street(int firstBuilding, int secondBuilding)
        {
            this.FirstBuilding = firstBuilding;
            this.SecondBuilding = secondBuilding;
        }

        public int FirstBuilding { get; set; }

        public int SecondBuilding { get; set; }

        public override string ToString()
            => $"{Math.Min(this.FirstBuilding, this.SecondBuilding)} {Math.Max(this.FirstBuilding, this.SecondBuilding)}";
    }
    
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static List<Street> streets;

        static void Main(string[] args)
        {
            var buildingCount = int.Parse(Console.ReadLine());
            var streetCount = int.Parse(Console.ReadLine());

            streets = new List<Street>(streetCount);
            graph = new Dictionary<int, List<int>>();
            ReadGraphAndExtractStreets(buildingCount, streetCount);

            var importantStreets = new List<Street>();

            foreach (var street in streets)
            {
                var first = street.FirstBuilding;
                var second = street.SecondBuilding;

                graph[first].Remove(second);
                graph[second].Remove(first);

                if (HasNoPath(first, second))
                {
                    importantStreets.Add(street);
                }

                graph[first].Add(second);
                graph[second].Add(first);
            }

            PrintImportantStreets(importantStreets);
        }

        private static void PrintImportantStreets(List<Street> importantStreets)
        {
            Console.WriteLine($"Important streets:");

            foreach (var importantStreet in importantStreets)
            {
                Console.WriteLine(importantStreet);
            }
        }

        private static bool HasNoPath(int startNode, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            var visited = new HashSet<int>();
            visited.Add(startNode);

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return false;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return true;
        }

        private static void ReadGraphAndExtractStreets(int buildingCount, int streetCount)
        {
            for (int i = 0; i < streetCount; i++)
            {
                var line = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var first = line[0];
                var second = line[1];

                if (!graph.ContainsKey(first))
                {
                    graph.Add(first, new List<int>());
                }

                if (!graph.ContainsKey(second))
                {
                    graph.Add(second, new List<int>());
                }

                graph[first].Add(second);
                graph[second].Add(first);

                streets.Add(new Street(first, second));
            }
        }
    }
}
