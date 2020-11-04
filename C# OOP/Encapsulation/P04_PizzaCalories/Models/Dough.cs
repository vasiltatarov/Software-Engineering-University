using P04_PizzaCalories.Exceptions;
using P04_PizzaCalories.Models;

namespace P04_PizzaCalories
{
    public class Dough
    {
        private double grams;
        private string flourType;
        private string techType;

        public Dough(string flourType, string techType, double grams)
        {
            this.FlourType = flourType;
            this.TechType = techType;
            this.Grams = grams;
        }

        public double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new GramsOutOfRangeException();
                }

                this.grams = value;
            }
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!DoughValidator.IsValidFlourType(value.ToLower()))
                {
                    throw new InvalidFlourTypeException();
                }

                this.flourType = value;
            }
        }

        public string TechType
        {
            get
            {
                return this.techType;
            }
            private set
            {
                if (!DoughValidator.IsValidTechType(value.ToLower()))
                {
                    throw new InvalidFlourTypeException();
                }

                this.techType = value;
            }
        }

        public double GetCalories()
            => DoughValidator.GetCalories(this.FlourType, this.TechType, this.Grams);
    }
}