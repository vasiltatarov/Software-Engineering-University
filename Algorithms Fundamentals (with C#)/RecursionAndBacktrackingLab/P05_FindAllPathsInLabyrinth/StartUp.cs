using System;
using System.Collections.Generic;

namespace P05_FindAllPathsInLabyrinth
{
    class StartUp
    {
        private static List<char> path = new List<char>();

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var labyrinth = new char[n, m];
            ReadElements(labyrinth);

            FindAllPaths(labyrinth, 0, 0, '\0');
        }

        private static void ReadElements(char[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                var data = Console.ReadLine();

                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    labyrinth[row, col] = data[col];
                }
            }
        }

        private static void FindAllPaths(char[,] labyrinth, int row, int col, char direction)
        {
            if (IsOutside(labyrinth, row, col) ||
                IsWall(labyrinth, row, col) ||
                IsVisited(labyrinth, row, col))
            {
                return;
            }

            path.Add(direction);

            if (IsSolution(labyrinth, row, col))
            {
                Console.WriteLine(string.Join("", path));
                path.RemoveAt(path.Count - 1);
                return;
            }

            labyrinth[row, col] = 'v';

            FindAllPaths(labyrinth, row, col + 1, 'R');
            FindAllPaths(labyrinth, row + 1, col, 'D');
            FindAllPaths(labyrinth, row, col - 1, 'L');
            FindAllPaths(labyrinth, row - 1, col, 'U');

            path.RemoveAt(path.Count - 1);
            labyrinth[row, col] = '-';
        }

        private static bool IsSolution(char[,] labyrinth, int row, int col)
            => labyrinth[row, col] == 'e';

        private static bool IsVisited(char[,] labyrinth, int row, int col)
            => labyrinth[row, col] == 'v';

        private static bool IsWall(char[,] labyrinth, int row, int col)
            => labyrinth[row, col] == '*';

        private static bool IsOutside(char[,] labyrinth, int row, int col)
            => row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1);
    }
}
