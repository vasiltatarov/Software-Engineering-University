using P04_PizzaCalories.Exceptions;

namespace P04_PizzaCalories.Models
{
    public class Topping
    {
        private double grams;
        private string bakingType;

        public Topping(string type, double grams)
        {
            this.BakingType = type;
            this.Grams = grams;
        }

        public string BakingType
        {
            get
            {
                return this.bakingType;
            }
            private set
            {
                if (!ToppingValidator.IsValidBakingType(value.ToLower()))
                {
                    throw new InvalidBakingTypeException($"Cannot place {value} on top of your pizza.");
                }

                this.bakingType = value;
            }
        }

        public double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new GramsOutOfRangeException($"{this.BakingType} weight should be in the range [1..50].");
                }

                this.grams = value;
            }
        }

        public double GetCalories()
            => ToppingValidator.GetCalories(this.BakingType, this.Grams);
    }
}
