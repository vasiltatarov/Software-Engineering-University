using System.Collections.Generic;
using CarShop.ViewModels.Cars;

namespace CarShop.Services
{
    public interface ICarsService
    {
        IEnumerable<CarViewModel> AllCarsForClient(string userId);

        IEnumerable<CarViewModel> AllCarsForMechanic();

        string Add(string model, int year, string pictureUrl, string plateNumber, string ownerId);
    }
}
