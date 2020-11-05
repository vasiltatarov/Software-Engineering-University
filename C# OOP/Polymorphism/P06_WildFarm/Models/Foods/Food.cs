using P06_WildFarm.Models.Foods.Contracts;

namespace P06_WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
