using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Musaca.Data;
using Musaca.Services;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;

namespace Musaca
{
    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IValidator, Validator>()
                    .Add<IUserService, UserService>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IProductService, ProductService>()
                    .Add<IReceiptService, ReceiptService>()
                    .Add<ApplicationDbContext>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
