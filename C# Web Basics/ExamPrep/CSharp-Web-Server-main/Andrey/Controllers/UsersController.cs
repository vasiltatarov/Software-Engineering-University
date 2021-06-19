using System.Linq;
using Andrey.Services;
using Andrey.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Andrey.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService userService;

        public UsersController(IValidator validator, IUserService userService)
        {
            this.validator = validator;
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var userId = this.userService.GetUserId(model.Username, model.Password);
            if (userId == null)
            {
                return this.Error("Invalid username or password!");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/");
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
            this.SignOut();

            return Redirect("/");
        }
    }
}
