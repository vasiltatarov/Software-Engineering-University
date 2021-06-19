using System.Threading.Tasks;
using Andrey.Data;
using Andrey.Services;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;

namespace Andrey
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
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IUserService, UserService>()
                    .Add<IProductService, ProductService>()
                    .Add<AndreysDbContext>())
                .WithConfiguration<AndreysDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
