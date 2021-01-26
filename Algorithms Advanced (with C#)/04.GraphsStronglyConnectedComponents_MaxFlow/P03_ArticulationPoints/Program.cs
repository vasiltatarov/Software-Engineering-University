using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_ArticulationPoints
{
    class Program
    {
        private static List<int>[] graph;
        private static int[] depths;
        private static int[] lowPoint;
        private static int[] parent;
        private static bool[] visited;
        private static List<int> articulationPoints;

        static void Main(string[] args)
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var linesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, linesCount);

            depths = new int[graph.Length];
            lowPoint = new int[graph.Length];
            parent = new int[graph.Length];
            visited = new bool[graph.Length];
            articulationPoints = new List<int>();

            Array.Fill(parent, -1);

            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    FindArticulationPoint(node, 1);
                }
            }

            Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
        }

        private static void FindArticulationPoint(int node, int depth)
        {
            visited[node] = true;
            lowPoint[node] = depth;
            depths[node] = depth;

            var childCount = 0;
            var isArticulationPoint = false;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    parent[child] = node;
                    FindArticulationPoint(child, depth + 1);
                    childCount++;

                    if (lowPoint[child] >= depth)
                    {
                        isArticulationPoint = true;
                    }

                    lowPoint[node] = Math.Min(lowPoint[child], lowPoint[node]);
                }
                else if (parent[node] != child)
                {
                    lowPoint[node] = Math.Min(lowPoint[node], depths[child]);
                }
            }

            if (parent[node] == -1 && childCount > 1 || 
                parent[node] != -1 && isArticulationPoint)
            {
                articulationPoints.Add(node);
            }
        }

        private static List<int>[] ReadGraph(int nodesCount, int linesCount)
        {
            var result = new List<int>[nodesCount];

            for (int node = 0; node < nodesCount; node++)
            {
                result[node] = new List<int>();
            }

            for (int i = 0; i < linesCount; i++)
            {
                var data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                var first = data[0];

                for (int j = 1; j < data.Length; j++)
                {
                    var second = data[j];

                    result[first].Add(second);
                    result[second].Add(first);
                }
            }

            return result;
        }
    }
}
