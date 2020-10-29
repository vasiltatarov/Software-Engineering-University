using System;
using System.Text;

namespace P02_ClassBoxData
{
    //Rectangular Parallelepiped
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        //Surface Area = 2lw + 2lh + 2wh
        public double GetSurfaceArea()
            => (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);


        //Lateral Surface Area = 2lh + 2wh
        public double GetLateralSurfaceArea()
            => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);


        //Volume = lwh
        public double GetVolume()
            => this.Length * this.Width * this.Height;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Surface Area - {this.GetSurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():F2}")
                .AppendLine($"Volume - {this.GetVolume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
