using System.Linq;
using Git.Services;
using Git.ViewModels.Commits;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;
        private readonly IRepositoryService repositoryService;
        private readonly IValidator validator;

        public CommitsController(ICommitService commitService, IRepositoryService repositoryService, IValidator validator)
        {
            this.commitService = commitService;
            this.repositoryService = repositoryService;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var viewModel = this.commitService.All(this.User.Id);

            return this.View(viewModel);
        }

        public HttpResponse Create(string id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var viewModel = this.repositoryService.GetById(id);
            
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CommitInputModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var errors = this.validator.ValidateCommit(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.commitService.Add(model.Description, model.Id, this.User.Id);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            this.commitService.Delete(id, this.User.Id);

            return this.Redirect("/Commits/All");
        }
    }
}
