namespace Musaca.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
