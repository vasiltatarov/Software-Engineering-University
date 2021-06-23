using System.Collections.Generic;
using CarShop.Models.Cars;

namespace CarShop.Services
{
    public interface ICarService
    {
        void Add(string model, int year, string image, string plateNumber, string ownerId);

        IEnumerable<CarListingViewModel> All(string userId);

        bool IsUserOwnsCar(string carId, string userId);
    }
}
