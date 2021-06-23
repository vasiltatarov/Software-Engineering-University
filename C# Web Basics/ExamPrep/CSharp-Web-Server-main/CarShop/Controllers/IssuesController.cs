using System.Linq;
using CarShop.Models.Issues;

namespace CarShop.Controllers
{
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class IssuesController : Controller
    {
        private readonly IUserService userService;
        private readonly IIssueService issueService;
        private readonly ICarService carService;
        private readonly IValidator validator;

        public IssuesController(IUserService userService, IIssueService issueService, ICarService carService, IValidator validator)
        {
            this.userService = userService;
            this.issueService = issueService;
            this.carService = carService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            var userId = this.User.Id;

            if (!this.userService.IsMechanic(userId))
            {
                if (!this.carService.IsUserOwnsCar(carId, userId))
                {
                    return Error("You do not have access to this car.");
                }
            }

            var carWithIssues = this.issueService.CarIssues(carId);
            if (carWithIssues == null)
            {
                return Error($"Car with ID '{carId}' does not exist.");
            }

            return View(carWithIssues);
        }

        [Authorize]
        public HttpResponse Add(string carId)
            => View(new AddIssueViewModel
        {
            CarId = carId
        });

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model)
        {
            if (!this.UserCanAccessCar(model.CarId))
            {
                return Unauthorized();
            }

            var modelErrors = this.validator.ValidateIssue(model);
            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            this.issueService.Add(model.Description, model.CarId);

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            if (!this.userService.IsMechanic(this.User.Id))
            {
                return Unauthorized();
            }

            this.issueService.Fix(issueId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            if (!this.UserCanAccessCar(carId))
            {
                return Unauthorized();
            }

            this.issueService.Delete(issueId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        private bool UserCanAccessCar(string carId)
        {
            var userIsMechanic = this.userService.IsMechanic(this.User.Id);

            if (!userIsMechanic)
            {
                var userOwnsCar = this.carService.IsUserOwnsCar(carId, this.User.Id);

                if (!userOwnsCar)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
