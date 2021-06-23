namespace CarShop.Controllers
{
    using System.Linq;
    using CarShop.Models.Cars;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService userService;
        private readonly ICarService carService;

        public CarsController(
            IValidator validator, 
            IUserService userService,
            ICarService carService)
        {
            this.validator = validator;
            this.userService = userService;
            this.carService = carService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (this.userService.IsMechanic(this.User.Id))
            {
                return Error("Mechanic cannot add car.");
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddCarFormModel model)
        {
            if (this.userService.IsMechanic(this.User.Id))
            {
                return Error("Mechanic cannot add car.");
            }

            var modelErrors = this.validator.ValidateCar(model);
            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            this.carService.Add(model.Model, model.Year, model.Image, model.PlateNumber, this.User.Id);

            return Redirect("/Cars/All");
        }

        [Authorize]
        public HttpResponse All()
            => View(this.carService.All(this.User.Id));
    }
}
