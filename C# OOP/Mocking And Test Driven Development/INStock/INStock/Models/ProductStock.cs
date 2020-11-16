using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public int Count => this.products.Count;

        public IProduct this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.products[index];
            }
            set
            {
                this.ValidateIndex(index);

                this.products[index] = value;
            }
        }

        public bool Contains(IProduct product)
            => this.products.Any(x => x.CompareTo(product) == 0);

        public void Add(IProduct product)
        {
            if (this.products.Any(x => x.CompareTo(product) == 0))
            {
                throw new InvalidOperationException("Product is already exist!");
            }

            this.products.Add(product);
        }

        public bool Remove(IProduct product)
        {
            if (this.products.Count == 0)
            {
                return false;
            }

            var found = this.Contains(product);

            if (found == false)
            {
                return false;
            }

            this.products.Remove(product);
            return true;
        }

        public IProduct Find(int index)
        {
            this.ValidateIndex(index);

            return this.products[index];
        }

        public IProduct FindByLabel(string label)
        {
            var searched = this.products.Find(x => x.Label == label);

            if (searched == null)
            {
                throw new ArgumentException("Product is not present in the stocks!");
            }

            return searched;
        }

        public IProduct FindMostExpensiveProduct()
            => this.products.OrderByDescending(x => x.Price).FirstOrDefault();

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
            => this.products.Where(x => x.Price >= lo && x.Price <= hi).OrderByDescending(x => x.Price);

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
            => this.products.Where(x => x.Price == price);

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
            => this.products.Where(x => x.Quantity == quantity);

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();


        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.products.Count)
            {
                throw new IndexOutOfRangeException("Invalid index!");
            }
        }
    }
}
