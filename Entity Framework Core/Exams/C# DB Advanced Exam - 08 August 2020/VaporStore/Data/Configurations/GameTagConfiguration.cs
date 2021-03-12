using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaporStore.Data.Models;

namespace VaporStore.Data.Configurations
{
    class GameTagConfiguration : IEntityTypeConfiguration<GameTag>

    {
        public void Configure(EntityTypeBuilder<GameTag> gameTag)
        {
            gameTag.HasKey(x => new {x.GameId, x.TagId});

            gameTag
                .HasOne(x => x.Game)
                .WithMany(x => x.GameTags)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            gameTag
                .HasOne(x => x.Tag)
                .WithMany(x => x.GameTags)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
