using System.Linq;
using MyWebServer.Controllers;
using MyWebServer.Http;
using Panda.Services;
using Panda.ViewModels.Packages;

namespace Panda.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackageService packageService;
        private readonly IValidator validator;

        public PackagesController(IPackageService packageService, IValidator validator)
        {
            this.packageService = packageService;
            this.validator = validator;
        }

        public HttpResponse Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var viewModel = this.packageService.Users();

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(PackageInputModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var errors = this.validator.ValidatePackage(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.packageService.Add(model.Description, model.Weight, model.ShippingAddress, model.RecipientName);

            return this.Redirect("/");
        }

        public HttpResponse Pending()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var viewModel = this.packageService.AllPending();

            return this.View(viewModel);
        }

        // Upon creation, a Receipt's Fee should be set to the Package's Weight multiplied (*) by 2.67.
        public HttpResponse Deliver(string id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            this.packageService.DeliveredPackage(id);

            return this.Redirect("/Packages/Pending");
        }

        public HttpResponse Delivered()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var viewModel = this.packageService.AllDelivered();

            return this.View(viewModel);
        }
    }
}
