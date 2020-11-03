using System;
using System.Collections.Generic;
using P06_WildFarm.Models.Foods;

namespace P06_WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double WEIGHT_MULTIPLAYER = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLAYER;

        public override ICollection<Type> PrefferedFoods => new List<Type>() {typeof(Meat)};

        public override string ProduceSound() => "Woof!";
    }
}
