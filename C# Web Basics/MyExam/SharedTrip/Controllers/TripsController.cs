namespace SharedTrip.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Trips;

    public class TripsController : Controller
    {
        private readonly ITripService tripService;
        private readonly IValidator validator;

        public TripsController(ITripService tripService, IValidator validator)
        {
            this.tripService = tripService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
            => this.View(this.tripService.All());

        [Authorize]
        public HttpResponse Add()
            => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(TripFormModel model)
        {
            var errors = this.validator.ValidateTrip(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.tripService.Add(
                model.StartPoint,
                model.EndPoint,
                DateTime.Parse(model.DepartureTime, CultureInfo.InstalledUICulture),
                model.ImagePath,
                model.Seats,
                model.Description);

            return this.Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
            => this.View(this.tripService.TripDetails(tripId));

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var isAddedSuccess = this.tripService.AddUserToTrip(this.User.Id, tripId);
            if (!isAddedSuccess)
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            return this.Redirect("/");
        }
    }
}
