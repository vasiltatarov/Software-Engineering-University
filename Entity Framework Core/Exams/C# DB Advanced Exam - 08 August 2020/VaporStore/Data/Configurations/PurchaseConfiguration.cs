using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaporStore.Data.Models;

namespace VaporStore.Data.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> purchase)
        {
            purchase.HasKey(x => x.Id);

            purchase
                .HasOne(x => x.Game)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            purchase
                .HasOne(x => x.Card)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.CardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
