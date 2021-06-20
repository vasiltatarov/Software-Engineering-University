using MyWebServer.Controllers;
using MyWebServer.Http;
using Panda.Services;

namespace Panda.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Home/IndexLoggedIn");
            }

            return this.View();
        }

        public HttpResponse IndexLoggedIn()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var viewModel = this.userService.GetUsername(this.User.Id);

            return this.View(viewModel);
        }
    }
}
