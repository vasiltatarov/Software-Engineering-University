using System;

namespace SnakeGame.Models
{
    public static class ReadUserInput
    {
        public static Position GetMovement(ConsoleKey key, Position oldMovement)
        {
            var position = oldMovement;

            switch (key)
            {
                case ConsoleKey.Escape:
                    return null;
                case ConsoleKey.UpArrow:
                    if (oldMovement.Y != 1)
                    {
                        position = new Position(0, -1);
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (oldMovement.Y != -1)
                    {
                        position = new Position(0, 1);
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    if (oldMovement.X != 1)
                    {
                        position = new Position(-1, 0);
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (oldMovement.X != -1)
                    {
                        position = new Position(1, 0);
                    }

                    break;
            }

            return position;
        }
    }
}
