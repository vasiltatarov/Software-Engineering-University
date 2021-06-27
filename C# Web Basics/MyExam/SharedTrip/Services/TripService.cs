namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.ViewModels.Trips;

    public class TripService : ITripService
    {
        private readonly ApplicationDbContext data;

        public TripService(ApplicationDbContext data) => this.data = data;

        public IEnumerable<TripViewModel> All()
            => this.data.Trips
                .Select(x => new TripViewModel
                {
                    Id = x.Id,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    EndPoint = x.EndPoint,
                    Seats = x.Seats,
                    StartPoint = x.StartPoint,
                })
                .ToList();

        public void Add(string startPoint, string endPoint, DateTime departureTime, string imagePath, int seats, string description)
        {
            var trip = new Trip
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = departureTime,
                ImagePath = imagePath,
                Seats = seats,
                Description = description,
            };

            this.data.Trips.Add(trip);
            this.data.SaveChanges();
        }

        public TripDetailsViewModel TripDetails(string tripId)
            => this.data.Trips
                .Where(x => x.Id == tripId)
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = x.Description,
                    Seats = x.Seats,
                    Image = x.ImagePath,
                    StartPoint = x.StartPoint,
                })
                .FirstOrDefault();

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userTrip = this.data.UserTrips
                .FirstOrDefault(x => x.UserId == userId && x.TripId == tripId);
            if (userTrip != null)
            {
                return false;
            }

            var trip = this.data.Trips.FirstOrDefault(x => x.Id == tripId);
            var freeSeats = trip.Seats;

            if (freeSeats <= 0)
            {
                return false;
            }

            trip.Seats -= 1;

            userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            this.data.UserTrips.Add(userTrip);
            this.data.SaveChanges();

            return true;
        }
    }
}
