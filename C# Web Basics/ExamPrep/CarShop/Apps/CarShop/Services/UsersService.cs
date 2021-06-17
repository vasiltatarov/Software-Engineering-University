using System;
using CarShop.Data;

using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CarShop.Data.Models;
using SUS.MvcFramework;

namespace CarShop.Services
{
    public class UsersService: IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db) => this.db = db;

        public void Create(string username, string email, string password, string userType)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Email = email,
                Password = ComputeHash(password),
                IsMechanic = userType.ToLower() == "mechanic",
                Role = IdentityRole.User,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = ComputeHash(password);
            var user = this.db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashPassword);

            return user == null ? null : user.Id;
        }

        public bool IsUserMechanic(string userId)
            => this.db.Users.First(x => x.Id == userId).IsMechanic;

        public bool IsUsernameAvailable(string username)
            => this.db.Users.Any(x => x.Username == username);

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);

            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}
