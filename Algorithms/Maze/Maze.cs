using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    public class Maze
    {
        public static string GetPathInMaze(string[] maze)
        {
            FindAllPaths(maze, 0, 0, new bool[maze.Length, maze[0].Length], "");

            string bestPath = FindBestPath();

            if (bestPath == null)
            {
                throw new InvalidOperationException("Cannot found Path to the Exit!!!");
            }

            var sb = new StringBuilder();

            PrintBestPath(bestPath, sb);
            PrintBestPathsAsMatrix(maze, bestPath, sb);

            return sb.ToString().TrimEnd();
        }

        private static string FindBestPath()
        {
            var bestPathLength = int.MaxValue;
            string bestPath = null;

            foreach (var path in bestPaths)
            {
                if (path.Length < bestPathLength)
                {
                    bestPath = path;
                    bestPathLength = path.Length;
                }
            }

            return bestPath;
        }

        private static void PrintBestPathsAsMatrix(string[] maze, string bestPath, StringBuilder sb)
        {
            var paths = new List<string>();
            var row = 0;
            var col = 0;
            paths.Add($"{row}{col}");

            for (int i = 0; i < bestPath.Length; i++)
            {
                var isValid = false;

                if (bestPath[i] == 'D')
                {
                    row++;
                    isValid = true;
                }
                else if (bestPath[i] == 'U')
                {
                    row--;
                    isValid = true;
                }
                else if (bestPath[i] == 'L')
                {
                    col--;
                    isValid = true;
                }
                else if (bestPath[i] == 'R')
                {
                    col++;
                    isValid = true;
                }

                if (isValid)
                {
                    paths.Add($"{row}{col}");
                }
            }

            sb.AppendLine(new string('-', maze[0].Length));

            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    if (paths.Contains($"{i}{j}"))
                    {
                        if (i == 0 && j == 0)
                        {
                            sb.Append('S');
                        }
                        else if (maze[i][j] == 'E')
                        {
                            sb.Append('E');
                        }
                        else
                        {
                            sb.Append('*');
                        }
                    }
                    else
                    {
                        sb.Append(maze[i][j]);
                    }
                }

                sb.AppendLine();
            }

            sb.AppendLine(new string('-', maze[0].Length));
        }

        private static void PrintBestPath(string bestPath, StringBuilder sb)
        {
            sb
                .AppendLine($"Best Path! - {bestPath}")
                .AppendLine("Start at - 'S'")
                .AppendLine("End at - 'E'");
        }

        private static List<string> bestPaths = new List<string>();

        private static void FindAllPaths(string[] maze, int row, int col, bool[,] visited, string path)
        {
            if (maze[row][col] == 'E')
            {
                bestPaths.Add(path);
                return;
            }

            visited[row, col] = true;

            if (IsValidMove(maze, row - 1, col, visited))
            {
                FindAllPaths(maze, row - 1, col, visited, path + "U");
            }
            if (IsValidMove(maze, row + 1, col, visited))
            {
                FindAllPaths(maze, row + 1, col, visited, path + "D");
            }
            if (IsValidMove(maze, row, col - 1, visited))
            {
                FindAllPaths(maze, row, col - 1, visited, path + "L");
            }
            if (IsValidMove(maze, row, col + 1, visited))
            {
                FindAllPaths(maze, row, col + 1, visited, path + "R");
            }

            visited[row, col] = false;
        }

        private static bool IsValidMove(string[] maze, int row, int col, bool[,] visited)
        {
            if (row < 0 || row >= maze.Length || col < 0 || col >= maze[0].Length)
            {
                return false;
            }

            if (visited[row, col] == true || maze[row][col] == '|')
            {
                return false;
            }

            return true;
        }
    }
}
