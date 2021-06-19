using System;
using System.Collections.Generic;
using System.Linq;
using Andrey.Data;
using Andrey.Data.Models;
using Andrey.ViewModels.Products;

namespace Andrey.Services
{
    public class ProductService : IProductService
    {
        private readonly AndreysDbContext data;

        public ProductService(AndreysDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<ProductViewModel> All()
            => this.data.Products
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Image = x.ImageUrl,
                    Name = x.Name,
                    Price = x.Price,
                })
                .ToList();

        public ProductDetailsViewModel GetProductById(string id)
            => this.data.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductDetailsViewModel
                {
                    Id = x.Id,
                    Image = x.ImageUrl,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Category = Enum.GetName(x.Category),
                    Gender = Enum.GetName(x.Gender),
                })
                .FirstOrDefault();

        public void Add(string name, string description, string image, decimal price, string category, string gender)
        {
            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Description = description,
                ImageUrl = image,
                Price = price,
                Category = Enum.Parse<Category>(category),
                Gender = Enum.Parse<Gender>(gender),
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();
        }

        public void Delete(string id)
        {
            var product = this.data.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return;
            }

            this.data.Products.Remove(product);
            this.data.SaveChanges();
        }
    }
}
