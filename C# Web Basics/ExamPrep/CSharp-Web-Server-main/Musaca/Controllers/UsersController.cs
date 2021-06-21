using System.Linq;
using Musaca.Services;
using Musaca.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Musaca.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IValidator validator;
        private readonly IProductService productService;
        private readonly IReceiptService receiptService;

        public UsersController(IUserService userService, IValidator validator, IProductService productService, IReceiptService receiptService)
        {
            this.userService = userService;
            this.validator = validator;
            this.productService = productService;
            this.receiptService = receiptService;
        }

        public HttpResponse Index()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var userId = this.User.Id;
            var products = this.productService.AllActiveForUser(userId);
            var viewModel = new IndexViewModel
            {
                Products = products,
                Sum = products.Sum(x => x.Price),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Index(string product)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var userId = this.User.Id;
            this.productService.OrderProductByUser(userId, product);

            return this.Redirect("/");
        }

        public HttpResponse Profile()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var userId = this.User.Id;
            var viewModel = this.receiptService.All(userId);

            return this.View(viewModel);
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Index");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Index");
            }

            var userId = this.userService.GetUserId(model.Username, model.Password);
            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Index");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Index");
            }

            if (this.userService.IsUsernameAvailable(model.Username))
            {
                return this.Error("User with this username is an already exist!");
            }

            var errors = this.validator.ValidateUser(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.userService.Create(model.Username, model.Email, model.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (this.User.IsAuthenticated)
            {
                this.SignOut();
            }

            return this.Redirect("/");
        }
    }
}
