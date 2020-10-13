using System;

namespace SnakeGame.Models
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void ChangePosition(Position position)
        {
            this.X += position.X;
            this.Y += position.Y;
        }

        public Position GetNewPosition(Position position)
        {
            return new Position(this.X + position.X, this.Y + position.Y);
        }

        public override bool Equals(object obj)
        {
            var current = (Position)obj;

            var isEqual = (this.X == current.X && this.Y == current.Y); 

            return isEqual;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
