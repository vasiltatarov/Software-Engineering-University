using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> song)
        {
            song.HasKey(x => x.Id);

            song
                .HasOne(x => x.Album)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            song
                .HasOne(x => x.Writer)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.WriterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
