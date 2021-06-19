using System.Collections.Generic;
using Andrey.Data.Models;
using Andrey.ViewModels.Products;

namespace Andrey.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> All();

        ProductDetailsViewModel GetProductById(string id);

        void Add(string name, string description, string image, decimal price, string category, string gender);

        void Delete(string id);
    }
}
