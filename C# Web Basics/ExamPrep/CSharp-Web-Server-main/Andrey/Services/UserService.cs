using System;
using System.Linq;
using Andrey.Data;
using Andrey.Data.Models;

namespace Andrey.Services
{
    public class UserService : IUserService
    {
        private readonly AndreysDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public UserService(AndreysDbContext data, IPasswordHasher passwordHasher)
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
                Id = Guid.NewGuid().ToString(),
                Email = email,
                Username = username,
                Password = this.passwordHasher.HashPassword(password),
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public bool IsUsernameAvailable(string username)
            => this.data.Users.Any(x => x.Username == username);
    }
}
