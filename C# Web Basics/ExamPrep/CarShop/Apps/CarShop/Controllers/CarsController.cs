using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels.Cars;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class CarsController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ICarsService carsService;

        public CarsController(IUsersService usersService, ICarsService carsService)
        {
            this.usersService = usersService;
            this.carsService = carsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (this.usersService.IsUserMechanic(userId))
            {
                var mechanicViewModel = this.carsService.AllCarsForMechanic();
                return this.View(mechanicViewModel);
            }

            var clientViewModel = this.carsService.AllCarsForClient(userId);

            return this.View(clientViewModel);
        }

        public HttpResponse Add()
        {
            var userId = this.GetUserId();

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            if (this.usersService.IsUserMechanic(userId))
            {
                return this.All();
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCarInputModel input)
        {
            var userId = this.GetUserId();

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Model) || input.Model.Length < 5 || input.Model.Length > 20)
            {
                return this.Error("Invalid Model");
            }

            if (string.IsNullOrWhiteSpace(input.Image))
            {
                return this.Error("Invalid Image");
            }

            if (!Regex.IsMatch(input.PlateNumber, @"^[A-Z]{2}[0-9]{4}[A-Z]{2}$"))
            {
                return this.Error("Invalid Plate Number");
            }

            if (this.usersService.IsUserMechanic(userId))
            {
                return this.All();
            }

            this.carsService.Add(input.Model, input.Year, input.Image, input.PlateNumber, userId);

            return this.All();
        }
    }
}
