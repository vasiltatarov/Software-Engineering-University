using System.Collections.Generic;
using P06_WildFarm.Models.Foods.Contracts;

namespace P06_WildFarm.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string ProduceSound();

        void Feed(IFood food);
    }
}
