using BookShop.Data.Models;

namespace BookShop.Data
{
    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasKey(x => new {x.AuthorId, x.BookId});

            modelBuilder.Entity<AuthorBook>()
                .HasOne(x => x.Author)
                .WithMany(x => x.AuthorsBooks)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(x => x.Book)
                .WithMany(x => x.AuthorsBooks)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}