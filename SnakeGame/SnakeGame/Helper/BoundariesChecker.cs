using SnakeGame.Models;
using System;

namespace SnakeGame.Helper
{
    public static class BoundariesChecker
    {
        public static void CheckPosition(Position headPosition, Position movement)
        {
            var newHeadPosition = headPosition.GetNewPosition(movement);

            if (newHeadPosition.Y == -1)
            {
                ConsoleHelper.Clear(headPosition);
                headPosition.Y = Console.WindowHeight - 1;
            }

            if (newHeadPosition.Y == Console.WindowHeight)
            {
                ConsoleHelper.Clear(headPosition);
                headPosition.Y = 0;
            }

            if (newHeadPosition.X == -1)
            {
                ConsoleHelper.Clear(headPosition);
                headPosition.X = Console.WindowWidth - 1;
            }

            if (newHeadPosition.X == Console.WindowWidth)
            {
                ConsoleHelper.Clear(headPosition);
                headPosition.X = 0;
            }
        }
    }
}
