using System.Collections.Generic;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Cars;
using System.Linq;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly CarShopDbContext data;
        private readonly IUserService userService;

        public CarService(CarShopDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public void Add(string model, int year, string image, string plateNumber, string ownerId)
        {
            var car = new Car
            {
                Model = model,
                Year = year,
                PictureUrl = image,
                PlateNumber = plateNumber,
                OwnerId = ownerId,
            };

            this.data.Cars.Add(car);

            this.data.SaveChanges();
        }

        public IEnumerable<CarListingViewModel> All(string userId)
        {
            var carsQuery = this.data.Cars.AsQueryable();

            if (this.userService.IsMechanic(userId))
            {
                carsQuery = carsQuery.Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuery = carsQuery.Where(c => c.OwnerId == userId);
            }

            var cars = carsQuery
                .Select(c => new CarListingViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    Image = c.PictureUrl,
                    PlateNumber = c.PlateNumber,
                    FixedIssues = c.Issues.Count(i => i.IsFixed),
                    RemainingIssues = c.Issues.Count(i => !i.IsFixed)
                })
                .ToList();

            return cars;
        }

        public bool IsUserOwnsCar(string carId, string userId)
            => this.data.Cars
                .Any(x => x.OwnerId == userId && x.Id == carId);
    }
}
