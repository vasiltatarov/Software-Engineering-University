using System;
using System.Collections.Generic;
using P06_WildFarm.Models.Foods;

namespace P06_WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WEIGHT_MULTIPLAYER = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLAYER;

        public override ICollection<Type> PrefferedFoods
            => new List<Type>() {typeof(Meat), typeof(Seeds), typeof(Fruit), typeof(Vegetable)};

        public override string ProduceSound()
            => "Cluck";
    }
}
