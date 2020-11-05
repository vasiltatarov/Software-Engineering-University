using System;
using System.Collections.Generic;
using P06_WildFarm.Exceptions;
using P06_WildFarm.Models.Contracts;
using P06_WildFarm.Models.Foods.Contracts;

namespace P06_WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        private const string DEF_FOOD_EXC = "{0} does not eat {1}!";

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PrefferedFoods { get; }

        public abstract string ProduceSound();

        public void Feed(IFood food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new UneatableFoodException(string.Format(DEF_FOOD_EXC, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
