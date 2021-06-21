using System;
using System.Collections.Generic;
using System.Linq;
using Musaca.Data;
using Musaca.Data.Models;
using Musaca.ViewModels.Products;

namespace Musaca.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext data;

        public ProductService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Add(string name, decimal price)
        {
            if (this.data.Products.Any(x => x.Name == name))
            {
                return;
            }

            var product = new Product
            {
                Name = name,
                Price = price,
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();
        }

        public IEnumerable<ProductViewModel> All()
            => this.data.Products
                .Select(x => new ProductViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                })
                .ToList();

        public IEnumerable<ProductViewModel> AllActiveForUser(string userId)
            => this.data.Orders
                .Where(x => x.Status == Status.Active && x.CashierId == userId)
                .Select(x => new ProductViewModel
                {
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                })
                .ToList();

        public void OrderProductByUser(string userId, string productName)
        {
            var product = this.data.Products.FirstOrDefault(x => x.Name == productName);
            if (product == null)
            {
                return;
            }

            var order = new Order
            {
                IssuedOn = DateTime.Now,
                Status = Status.Active,
                CashierId = userId,
                ProductId = product.Id,
            };

            this.data.Orders.Add(order);
            this.data.SaveChanges();
        }
    }
}
