using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;

namespace MusicHub.Data.Configurations
{
    public class SongPerformerConfiguration : IEntityTypeConfiguration<SongPerformer>
    {
        public void Configure(EntityTypeBuilder<SongPerformer> SongPerformer)
        {
            SongPerformer.HasKey(x => new {x.SongId, x.PerformerId});

            SongPerformer
                .HasOne(x => x.Song)
                .WithMany(x => x.SongPerformers)
                .HasForeignKey(x => x.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            SongPerformer
                .HasOne(x => x.Performer)
                .WithMany(x => x.PerformerSongs)
                .HasForeignKey(x => x.PerformerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
