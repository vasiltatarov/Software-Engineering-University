namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;

    using SharedTrip.ViewModels.Trips;

    public interface ITripService
    {
        IEnumerable<TripViewModel> All();

        void Add(string startPoint, string endPoint, DateTime departureTime, string imagePath, int seats, string description);

        TripDetailsViewModel TripDetails(string tripId);

        bool AddUserToTrip(string userId, string tripId);
    }
}
