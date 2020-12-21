using System;
using System.Collections.Generic;

namespace P03_CyclesInAGraph
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        static void Main()
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }
            }

            Console.WriteLine("Acyclic: Yes");
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }

            cycles.Add(node);
            visited.Add(node);

            if (!graph.ContainsKey(node))
            {
                return;
            }

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var resultedGraph = new Dictionary<string, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var args = line.Split("-");
                var key = args[0];
                var destination = args[1];

                if (!resultedGraph.ContainsKey(key))
                {
                    resultedGraph.Add(key, new List<string>());
                }

                resultedGraph[key].Add(destination);
            }

            return resultedGraph;
        }
    }
}
