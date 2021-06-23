using CarShop.Models.Issues;

namespace CarShop.Services
{
    public interface IIssueService
    {
        CarIssuesViewModel CarIssues(string carId);

        void Add(string description, string carId);

        void Delete(string issueId);

        void Fix(string issueId);
    }
}
