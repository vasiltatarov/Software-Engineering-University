using System.Collections.Generic;
using Musaca.ViewModels.Products;

namespace Musaca.Services
{
    public interface IProductService
    {
        void Add(string name, decimal price);

        IEnumerable<ProductViewModel> All();

        IEnumerable<ProductViewModel> AllActiveForUser(string userId);

        void OrderProductByUser(string userId, string productName);
    }
}
