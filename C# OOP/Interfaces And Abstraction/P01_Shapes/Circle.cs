using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }

        public string Draw()
        {
            var sb = new StringBuilder();
            var rIn = this.radius - 0.4d;
            var rOut = this.radius + 0.4d;

            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    var value = (x * x) + (y * y);

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
