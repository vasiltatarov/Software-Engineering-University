using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_SourceRemovalTopologicalSorting
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        static void Main()
        {
            try
            {
                var n = int.Parse(Console.ReadLine());

                graph = ReadGraph(n);
                dependencies = ExtractDependencies();
                var sorted = TopologicalSort();

                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<string> TopologicalSort()
        {
            var sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var node = dependencies.FirstOrDefault(x => x.Value == 0);

                if (node.Key == null)
                {
                    break;
                }

                var key = node.Key;
                var children = graph[node.Key];

                sorted.Add(key);

                foreach (var child in children)
                {
                    dependencies[child]--;
                }

                dependencies.Remove(key);
            }

            if (dependencies.Count > 0)
            {
                throw new InvalidOperationException("Invalid topological sorting");
            }

            return sorted;
        }

        private static Dictionary<string, int> ExtractDependencies()
        {
            var dependenciesResult = new Dictionary<string, int>();

            foreach (var (key, children) in graph)
            {
                if (!dependenciesResult.ContainsKey(key))
                {
                    dependenciesResult.Add(key, 0);
                }

                foreach (var child in children)
                {
                    if (!dependenciesResult.ContainsKey(child))
                    {
                        dependenciesResult.Add(child, 0);
                    }

                    dependenciesResult[child]++;
                }
            }

            return dependenciesResult;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new string[] { "->", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                var key = line[0];
                var childrens = line.Skip(1).ToList();

                result.Add(key, new List<string>(childrens));
            }

            return result;
        }
    }
}