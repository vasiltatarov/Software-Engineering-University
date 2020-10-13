using SnakeGame.Helper;
using SnakeGame.Interfaces;
using System;

namespace SnakeGame.Models
{
    public class Food : IDrawable
    {
        private bool isEaten = false;

        public Food(Position position, char symbol = '@')
        {
            this.Position = position;
            this.Symbol = symbol;
        }

        public Position Position { get; set; }
        public char Symbol { get; set; }

        public void EatenFood()
        {
            ConsoleHelper.Clear(this.Position);
            this.isEaten = true;
        }

        public void Draw()
        {
            if (!this.isEaten)
            {
                ConsoleHelper.Write(this.Position, this.Symbol.ToString());
            }
        }
    }
}
