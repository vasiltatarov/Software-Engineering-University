using Panda.ViewModels.Users;

namespace Panda.Services
{
    public interface IUserService
    {
        string GetUserId(string username, string password);

        void Create(string username, string email, string password);

        bool IsUsernameAvailable(string username);

        HomeUsernameViewModel GetUsername(string id);

        string GetUserId(string username);
    }
}
