using System;
using System.Linq;
using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Add(string description, string carId)
        {
            var issue = new Issue
            {
                Id = Guid.NewGuid().ToString(),
                Description = description,
                CarId = carId,
            };

            this.db.Issues.Add(issue);
            this.db.SaveChanges();

            return issue.Id;
        }

        public CarIssuesViewModel CarIssues(string carId)
            => this.db.Cars
                .Where(x => x.Id == carId)
                .Select(x => new CarIssuesViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    Issues = x.Issues
                        .Select(i => new IssuesViewModel
                        {
                            Id = i.Id,
                            Description = i.Description,
                            IsFixed = i.IsFixed,
                        })
                        .ToList(),
                })
                .FirstOrDefault();

        public void FixIssue(string issueId)
        {
            var issue = this.db.Issues.FirstOrDefault(x => x.Id == issueId);

            if (issue == null || issue.IsFixed)
            {
                return;
            }

            issue.IsFixed = true;
            this.db.SaveChanges();
        }

        public void Delete(string issueId)
        {
            var issue = this.db.Issues.FirstOrDefault(x => x.Id == issueId);

            if (issue == null)
            {
                return;
            }

            this.db.Issues.Remove(issue);
            this.db.SaveChanges();
        }
    }
}
