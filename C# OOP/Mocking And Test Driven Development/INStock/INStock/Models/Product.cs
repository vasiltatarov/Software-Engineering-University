using INStock.Contracts;

namespace INStock.Models
{
    public class Product : IProduct
    {
        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label { get; }

        public decimal Price { get; }

        public int Quantity { get; }

        public int CompareTo(IProduct other)
            => this.Label.CompareTo(other.Label);
    }
}
