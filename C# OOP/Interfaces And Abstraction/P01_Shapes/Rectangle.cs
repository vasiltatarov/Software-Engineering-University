using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public string Draw()
        {
            var sb = new StringBuilder();
            this.DrawLine(this.width, '*', '*', sb);

            for (int i = 1; i < this.height - 1; ++i)
            {
                this.DrawLine(this.width, '*', ' ', sb);
            }

            this.DrawLine(this.width, '*', '*', sb);

            return sb.ToString().TrimEnd();
        }

        private void DrawLine(int width, char end, char mid, StringBuilder sb)
        {
            sb.Append(end);

            for (int i = 1; i < width - 1; ++i)
            {
                sb.Append(mid);
            }

            sb.AppendLine(end.ToString());
        }
    }
}
