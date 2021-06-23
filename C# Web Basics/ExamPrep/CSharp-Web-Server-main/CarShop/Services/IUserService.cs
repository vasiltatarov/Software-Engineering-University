namespace CarShop.Services
{
    public interface IUserService
    {
        bool IsMechanic(string userId);

        string GetUserId(string username, string password);

        void Create(string username, string email, string password, string userType);

        bool IsUsernameExist(string username);

        bool IsEmailExist(string username);
    }
}
