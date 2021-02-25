using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> player)
        {
            player.HasKey(p => p.PlayerId);

            player.Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            player.Property(c => c.SquadNumber)
                .IsRequired(true);

            player.Property(c => c.IsInjured)
                .IsRequired(true);

            player
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            player
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(t => t.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
