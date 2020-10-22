using System;

namespace Maze
{
    public class StartUp
    {
        public static void Main()
        {
            string[] maze = new string[]
            {
                " |   |             |   | E",
                " | | | |   |   |      |   ",
                " | |   |    |  |   |   |  ",
                "   | | |       | | |      "
            };

            var pathInMaze = Maze.GetPathInMaze(maze);

            Console.WriteLine(pathInMaze);
        }
    }
}
