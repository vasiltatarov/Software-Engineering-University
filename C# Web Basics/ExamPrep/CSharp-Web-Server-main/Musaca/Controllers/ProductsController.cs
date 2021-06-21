using Musaca.Services;
using Musaca.ViewModels.Products;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Musaca.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly IProductService productService;
        private readonly IReceiptService receiptService;

        public ProductsController(IValidator validator, IProductService productService, IReceiptService receiptService)
        {
            this.validator = validator;
            this.productService = productService;
            this.receiptService = receiptService;
        }

        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var viewModel = this.productService.All();

            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(ProductInputModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            this.validator.ValidateProduct(model);
            this.productService.Add(model.Name, model.Price);

            return this.Redirect("/Products/All");
        }

        public HttpResponse Cashout()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var userId = this.User.Id;
            this.receiptService.Create(userId);

            return this.Redirect("/");
        }
    }
}
