using System.Linq;
using BattleCards.Services;
using BattleCards.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IValidator validator;

        public UsersController(IUserService userService, IValidator validator)
        {
            this.userService = userService;
            this.validator = validator;
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

            if (this.userService.IsUsernameAvailable(model.Username))
            {
                return this.Error("User with this name already exists!");
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

            return this.Redirect("/");
        }
    }
}
