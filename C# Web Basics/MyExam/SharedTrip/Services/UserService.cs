namespace SharedTrip.Services
{
    using System.Linq;

    using SharedTrip.Data;
    using SharedTrip.Data.Models;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public UserService(ApplicationDbContext data, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public string GetUserId(string username, string password)
        {
            var hashPass = this.passwordHasher.HashPassword(password);
            var user = this.data.Users.FirstOrDefault(x => x.Username == username && x.Password == hashPass);

            return user == null ? null : user.Id;
        }

        public void Create(string username, string email, string password)
        {
            var user = new User
            {
                Email = email,
                Username = username,
                Password = this.passwordHasher.HashPassword(password),
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public bool IsUsernameExist(string username)
            => this.data.Users.Any(x => x.Username == username);
    }
}
