using System;
using System.Collections.Generic;
using P06_WildFarm.Models.Foods;

namespace P06_WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double WEIGHT_MULTIPLAYER = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLAYER;

        public override ICollection<Type> PrefferedFoods => new List<Type>() {typeof(Meat)};

        public override string ProduceSound() => "Hoot Hoot";
    }
}
