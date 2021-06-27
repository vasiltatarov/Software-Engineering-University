namespace SharedTrip.Services
{
    public interface IUserService
    {
        string GetUserId(string username, string password);

        void Create(string username, string email, string password);

        bool IsUsernameExist(string username);
    }
}
