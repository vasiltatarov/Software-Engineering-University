using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_MaximumTasksAssignment
{
    class Program
    {
        private static int[,] graph;
        private static int[] parents;

        static void Main(string[] args)
        {
            var people = int.Parse(Console.ReadLine());
            var tasks = int.Parse(Console.ReadLine());

            graph = ReadGraph(people, tasks);
            var nodes = graph.GetLength(0);

            parents = new int[nodes];
            Array.Fill(parents, -1);

            var start = 0;
            var target = nodes - 1;

            while (BFS(start, target))
            {
                var node = target;
                while (node != start)
                {
                    var parent = parents[node];

                    graph[parent, node] = 0;
                    graph[node, parent] = 1;

                    node = parent;
                }
            }

            for (int person = 1; person <= people; person++)
            {
                for (int task = people + 1; task <= people + tasks; task++)
                {
                    if (graph[task, person] > 0)
                    {
                        Console.WriteLine($"{(char)(64 + person)}-{task - people}");
                    }
                }
            }
        }

        private static bool BFS(int start, int target)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var visited = new bool[graph.GetLength(0)];
            visited[start] = true;

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node == target)
                {
                    return true;
                }

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] &&
                        graph[node, child] > 0)
                    {
                        visited[child] = true; 
                        parents[child] = node;
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

        private static int[,] ReadGraph(int people, int tasks)
        {
            var nodes = people + tasks + 2;
            var result = new int[nodes, nodes];

            var start = 0;
            var target = nodes - 1;

            for (int person = 1; person <= people; person++)
            {
                result[start, person] = 1;
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                result[task, target] = 1;
            }

            for (int person = 1; person <= people; person++)
            {
                var data = Console.ReadLine();

                for (int task = 0; task < data.Length; task++)
                {
                    if (data[task] == 'Y')
                    {
                        result[person, people + 1 + task] = 1;
                    }
                }
            }

            return result;
        }
    }
}
