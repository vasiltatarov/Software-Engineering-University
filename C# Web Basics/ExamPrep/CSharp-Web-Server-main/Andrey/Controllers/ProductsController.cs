using System.Linq;
using Andrey.Services;
using Andrey.ViewModels.Products;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Andrey.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly IValidator validator;

        public ProductsController(IProductService productService, IValidator validator)
        {
            this.productService = productService;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.productService.All();

            return this.View(viewModel);
        }

        public HttpResponse Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductInputModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var errors = this.validator.ValidateProduct(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.productService.Add(model.Name, model.Description, model.ImageUrl, model.Price, model.Category, model.Gender);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.productService.GetProductById(id);

            return this.View(viewModel);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            this.productService.Delete(id);

            return this.Redirect("/");
        }
    }
}
