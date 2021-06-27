namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
            => this.User.IsAuthenticated
                ? this.Redirect("/Trips/All")
                : this.View();
    }
}