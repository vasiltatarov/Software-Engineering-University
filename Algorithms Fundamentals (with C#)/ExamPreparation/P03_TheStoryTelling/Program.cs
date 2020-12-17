using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_TheStoryTelling
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static Stack<string> result;

        static void Main()
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            result = new Stack<string>();

            foreach (var graphKey in graph.Keys)
            {
                if (visited.Contains(graphKey))
                {
                    continue;
                }

                Dfs(graphKey);
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void Dfs(string node)
        {
            if (visited.Contains(node)) 
            {
                return; 
            }

            foreach (var child in graph[node])
            {
                Dfs(child);
            }

            visited.Add(node);
            result.Push(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var args = line.Split(new string[] {" ", "->"}, StringSplitOptions.RemoveEmptyEntries);
                var preStory = args[0];
                var postStories = args.Skip(1).ToArray();

                if (!result.ContainsKey(preStory))
                {
                    result.Add(preStory, new List<string>());
                }

                foreach (var postStory in postStories)
                {
                    result[preStory].Add(postStory);
                }
            }

            return result;
        }
    }
}
