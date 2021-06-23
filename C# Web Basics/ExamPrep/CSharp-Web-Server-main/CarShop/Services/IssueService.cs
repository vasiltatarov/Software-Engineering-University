using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Issues;

namespace CarShop.Services
{
    public class IssueService : IIssueService
    {
        private readonly CarShopDbContext data;
        private readonly IUserService userService;

        public IssueService(CarShopDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public CarIssuesViewModel CarIssues(string carId)
            => this.data
                .Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarIssuesViewModel
                {
                    Id = c.Id,
                    Model = c.Model,
                    Year = c.Year,
                    Issues = c.Issues.Select(i => new IssueListingViewModel
                    {
                        Id = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed
                    })
                })
                .FirstOrDefault();

        public void Add(string description, string carId)
        {
            var issue = new Issue
            {
                Description = description,
                CarId = carId,
            };

            this.data.Issues.Add(issue);
            this.data.SaveChanges();
        }

        public void Delete(string issueId)
        {
            var issue = this.data.Issues.Find(issueId);

            this.data.Issues.Remove(issue);

            this.data.SaveChanges();
        }

        public void Fix(string issueId)
        {
            var issue = this.data.Issues.Find(issueId);
            issue.IsFixed = true;

            this.data.SaveChanges();
        }
    }
}
