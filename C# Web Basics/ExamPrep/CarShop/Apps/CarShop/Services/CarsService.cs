using System;
using System.Collections.Generic;
using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarViewModel> AllCarsForClient(string userId)
            => this.db.Cars
                .Where(x => x.OwnerId == userId)
                .Select(x => new CarViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    PictureUrl = x.PictureUrl,
                    PlateNumber = x.PlateNumber,
                    OwnerId = x.OwnerId,
                    UnfixedIssues = x.Issues.Count(i => !i.IsFixed),
                    FixedIssues = x.Issues.Count(i => i.IsFixed),
                })
                .ToList();

        public IEnumerable<CarViewModel> AllCarsForMechanic()
            => this.db.Cars
                .Where(x => x.Issues.Any(i => !i.IsFixed))
                .Select(x => new CarViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    PictureUrl = x.PictureUrl,
                    PlateNumber = x.PlateNumber,
                    OwnerId = x.OwnerId,
                    UnfixedIssues = x.Issues.Count(i => !i.IsFixed),
                    FixedIssues = x.Issues.Count(i => i.IsFixed),
                })
                .ToList();

        public string Add(string model, int year, string pictureUrl, string plateNumber, string ownerId)
        {
            var car = new Car
            {
                Id = Guid.NewGuid().ToString(),
                Model = model,
                Year = year,
                PictureUrl = pictureUrl,
                PlateNumber = plateNumber,
                OwnerId = ownerId,
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();

            return car.Id;
        }
    }
}
