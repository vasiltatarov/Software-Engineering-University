namespace CarShop.Controllers
{
    using CarShop.Services;
    using CarShop.ViewModels.Issues;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class IssuesController : Controller
    {
        private readonly IIssuesService issuesService;
        private readonly IUsersService usersService;

        public IssuesController(IIssuesService issuesService, IUsersService usersService)
        {
            this.issuesService = issuesService;
            this.usersService = usersService;
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.issuesService.CarIssues(carId);

            return this.View(viewModel);
        }

        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View(carId);
        }

        [HttpPost]
        public HttpResponse Add(string carId, IssueInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Description) || input.Description.Length < 5)
            {
                return this.Error("Invalid description. The description should be more than 5 symbols!");
            }

            this.issuesService.Add(input.Description, carId);

            return this.CarIssues(carId);
        }

        public HttpResponse Fix(string issueId, string carId)
        {
            var userId = this.GetUserId();

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.usersService.IsUserMechanic(userId))
            {
                return this.CarIssues(carId);
            }

            this.issuesService.FixIssue(issueId);

            return this.CarIssues(carId);
        }

        public HttpResponse Delete(string issueId, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.issuesService.Delete(issueId);

            return this.CarIssues(carId);
        }
    }
}
