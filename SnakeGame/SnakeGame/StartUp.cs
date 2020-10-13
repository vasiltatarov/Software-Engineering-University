using SnakeGame.Models;
using System;

namespace SnakeGame
{
    public class StartUp
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            //Console.BufferHeight = Console.WindowHeight;
            var snake = new GameEngine();
            snake.Start();
        }
    }
}
