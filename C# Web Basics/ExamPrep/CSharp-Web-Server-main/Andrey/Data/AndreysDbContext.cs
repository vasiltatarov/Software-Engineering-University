using Andrey.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Andrey.Data
{
    public class AndreysDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Andrey;Integrated Security=True;");
            }
        }
    }
}
