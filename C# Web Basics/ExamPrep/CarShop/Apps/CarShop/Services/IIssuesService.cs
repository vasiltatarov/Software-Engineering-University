using CarShop.ViewModels.Cars;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        string Add(string description, string carId);

        CarIssuesViewModel CarIssues(string carId);

        void FixIssue(string issueId);

        void Delete(string issueId);
    }
}
