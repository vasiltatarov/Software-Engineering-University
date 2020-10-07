using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight = 0, string color = null)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }
        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var empty = "n/a";
            var displacement = this.Engine.Displacement;
            var efficiency = this.Engine.Efficiency;
            var weight = this.Weight;
            var color = this.Color;

            sb
                .AppendLine($"{this.Model}:")
                .AppendLine($"  {this.Engine.Model}:")
                .AppendLine($"    Power: {this.Engine.Power}");

            if (displacement == 0)
            {
                sb.AppendLine($"    Displacement: {empty}");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Engine.Displacement}");
            }

            if (efficiency == null)
            {
                sb.AppendLine($"    Efficiency: {empty}");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            }

            if (weight == 0)
            {
                sb.AppendLine($"  Weight: {empty}");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.Weight}");
            }

            if (color == null)
            {
                sb.AppendLine($"  Color: {empty}");
            }
            else
            {
                sb.AppendLine($"  Color: {this.Color}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
