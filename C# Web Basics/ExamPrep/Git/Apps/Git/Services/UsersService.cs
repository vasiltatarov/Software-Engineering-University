namespace Git.Services
{
    using System.Linq;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    using Git.Data;
    using Git.Data.Models;
    using SUS.MvcFramework;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db) => this.db = db;

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Email = email,
                Password = ComputeHash(password),
                Role = IdentityRole.User,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        public bool IsEmailAvailable(string email)
            => !this.db.Users.Any(x => x.Email == email);

        public string GetUserId(string username, string password)
        {
            var hashPass = ComputeHash(password);
            var user = this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashPass);

            return user == null ? null : user.Id;
        }

        public bool IsUsernameAvailable(string username)
            => !this.db.Users.Any(x => x.Username == username);

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
