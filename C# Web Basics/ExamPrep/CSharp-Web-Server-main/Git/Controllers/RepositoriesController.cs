using System.Linq;
using Git.Services;
using Git.ViewModels.Repositories;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;
        private readonly IValidator validator;

        public RepositoriesController(IRepositoryService repositoryService, IValidator validator)
        {
            this.repositoryService = repositoryService;
            this.validator = validator;
        }

        public HttpResponse All()
            => this.View(this.repositoryService.All());

        public HttpResponse Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RepositoryInputModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var errors = this.validator.ValidateRepository(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            var userId = this.User.Id;
            this.repositoryService.Add(model.Name, model.RepositoryType, userId);

            return this.Redirect("/");
        }
    }
}
