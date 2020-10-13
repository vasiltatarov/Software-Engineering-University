using SnakeGame.Models;
using System;

namespace SnakeGame.Helper
{
    public class ConsoleHelper
    {
        public static void Clear(Position position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(" ");
        }

        public static void Write(Position position, string text)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(text);
        }
    }
}
