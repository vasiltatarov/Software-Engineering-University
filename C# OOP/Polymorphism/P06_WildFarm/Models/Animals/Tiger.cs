using System;
using System.Collections.Generic;
using P06_WildFarm.Models.Foods;

namespace P06_WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double WEIGHT_MULTIPLAYER = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLAYER;

        public override ICollection<Type> PrefferedFoods => new List<Type>() {typeof(Meat)};

        public override string ProduceSound() => "ROAR!!!";
    }
}
