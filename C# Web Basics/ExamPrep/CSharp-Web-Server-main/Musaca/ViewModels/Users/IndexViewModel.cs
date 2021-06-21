using System.Collections.Generic;
using Musaca.ViewModels.Products;

namespace Musaca.ViewModels.Users
{
    public class IndexViewModel
    {
        public decimal Sum { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
