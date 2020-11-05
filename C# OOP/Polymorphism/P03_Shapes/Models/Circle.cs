using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
            => Math.PI * this.radius * this.radius;

        public override double CalculatePerimeter()
            => 2 * Math.PI * this.radius;

        public override string Draw()
            => base.Draw() + this.GetType().Name;
    }
}