using System;
using System.Linq;
using BattleCards.Data;
using BattleCards.Data.Models;

namespace BattleCards.Services
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
    }
}
