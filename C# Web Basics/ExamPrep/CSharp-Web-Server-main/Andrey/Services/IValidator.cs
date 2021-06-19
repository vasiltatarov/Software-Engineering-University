using System.Collections.Generic;
using Andrey.ViewModels.Products;
using Andrey.ViewModels.Users;

namespace Andrey.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateProduct(ProductInputModel model);
    }
}
