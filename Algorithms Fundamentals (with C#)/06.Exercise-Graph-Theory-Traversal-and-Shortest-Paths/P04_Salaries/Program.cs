using System;
using System.Collections.Generic;

namespace P04_Salaries
{
    class Program
    {
        private static List<int>[] graph;
        private static HashSet<int> visited;
        private static Dictionary<int, int> memoazation;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
            visited = new HashSet<int>();
            memoazation = new Dictionary<int, int>();
            var totalSalary = 0;

            for (int node = 0; node < graph.Length; node++)
            {
                var salary = GetSalary(node);
                totalSalary += salary;
            }

            Console.WriteLine(totalSalary);
        }

        private static int GetSalary(int node)
        {
            // node
            // regular - salary 1
            // manager - salary - sum of its children salary

            if (graph[node].Count == 0)
            {
                return 1;
            }

            if (memoazation.ContainsKey(node))
            {
                return memoazation[node];
            }

            var salary = 0;

            foreach (var child in graph[node])
            {
                salary += GetSalary(child);
            }

            memoazation.Add(node, salary);

            return salary;
        }

        private static List<int>[] ReadGraph(int n)
        {
            var resultedGraph = new List<int>[n];

            for (int node = 0; node < n; node++)
            {
                resultedGraph[node] = new List<int>();
                var children = Console.ReadLine();

                for (int child = 0; child < children.Length; child++)
                {
                    if (children[child] == 'N')
                    {
                        continue;
                    }

                    resultedGraph[node].Add(child);
                }
            }

            return resultedGraph;
        }
    }
}
