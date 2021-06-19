namespace Andrey.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
