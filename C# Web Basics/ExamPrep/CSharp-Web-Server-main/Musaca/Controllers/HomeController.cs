using Musaca.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Musaca.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService) => this.userService = userService;

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Index");
            }

            return this.View();
        }
    }
}
