using System.Collections.Generic;
using Panda.ViewModels.Packages;
using Panda.ViewModels.Users;

namespace Panda.Services
{
    public interface IPackageService
    {
        IEnumerable<UserNameViewModel> Users();

        void Add(string description, double weight, string shippingAddress, string recipient);

        IEnumerable<PackageViewModel> AllPending();

        IEnumerable<DeliveredPackageViewModel> AllDelivered();

        void DeliveredPackage(string packageId);
    }
}
