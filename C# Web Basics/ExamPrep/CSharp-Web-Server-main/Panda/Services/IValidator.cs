using System.Collections.Generic;
using Panda.ViewModels.Packages;
using Panda.ViewModels.Users;

namespace Panda.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidatePackage(PackageInputModel model);
    }
}
