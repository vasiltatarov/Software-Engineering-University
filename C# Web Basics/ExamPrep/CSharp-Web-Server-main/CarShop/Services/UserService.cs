using System;
using CarShop.Data.Models;

namespace CarShop.Services
{
    using System.Linq;
    using CarShop.Data;

    public class UserService : IUserService
    {
        private readonly CarShopDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public UserService(CarShopDbContext data, IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.passwordHasher = passwordHasher;
        }

        public bool IsMechanic(string userId)
            => this.data
                .Users
                .Any(u => u.Id == userId && u.IsMechanic);

        public string GetUserId(string username, string password)
        {
            var passHash = this.passwordHasher.HashPassword(password);
            var user = this.data.Users.FirstOrDefault(x => x.Username == username && x.Password == passHash);

            return user == null ? null : user.Id;
        }

        public void Create(string username, string email, string password, string userType)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.passwordHasher.HashPassword(password),
                IsMechanic = userType == "Mechanic",
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public bool IsUsernameExist(string username)
            => this.data.Users.Any(x => x.Username == username);

        public bool IsEmailExist(string email)
            => this.data.Users.Any(x => x.Email == email);
    }
}
