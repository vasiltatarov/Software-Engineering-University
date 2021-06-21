using System.Collections.Generic;
using Musaca.ViewModels.Products;
using Musaca.ViewModels.Users;

namespace Musaca.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateProduct(ProductInputModel model);
    }
}
