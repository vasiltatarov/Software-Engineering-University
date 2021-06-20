using System.Linq;
using Panda.Data;
using Panda.Data.Models;
using Panda.ViewModels.Users;

namespace Panda.Services
{
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
            var passHash = this.passwordHasher.HashPassword(password);
            var user = this.data.Users.FirstOrDefault(x => x.Username == username && x.Password == passHash);

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

        public bool IsUsernameAvailable(string username)
            => this.data.Users.Any(x => x.Username == username);

        public HomeUsernameViewModel GetUsername(string id)
            => this.data.Users
                .Where(x => x.Id == id)
                .Select(x => new HomeUsernameViewModel
                {
                    Name = x.Username,
                })
                .FirstOrDefault();

        public string GetUserId(string username)
        {
            var user = this.data.Users.FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                return null;
            }

            return user.Id;
        }
    }
}
