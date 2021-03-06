using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> album)
        {
            album.HasKey(x => x.Id);

            album
                .HasOne(x => x.Producer)
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
