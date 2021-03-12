using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Data.Configurations
{
    public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> authorBook)
        {
            authorBook.HasKey(x => new {x.AuthorId, x.BookId});

            authorBook
                .HasOne(x => x.Author)
                .WithMany(x => x.AuthorsBooks)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            authorBook
                .HasOne(x => x.Book)
                .WithMany(x => x.AuthorsBooks)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
