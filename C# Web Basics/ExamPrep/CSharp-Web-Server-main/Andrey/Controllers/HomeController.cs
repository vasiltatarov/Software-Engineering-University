using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Andrey.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Products/All");
            }

            return this.View();
        }
    }
}
