using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
            => this.User.IsAuthenticated
                ? this.Redirect("/Repositories/All")
                : this.View();
    }
}
