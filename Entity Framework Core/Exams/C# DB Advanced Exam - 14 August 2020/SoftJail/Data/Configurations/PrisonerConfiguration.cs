using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data.Configurations
{
    public class PrisonerConfiguration : IEntityTypeConfiguration<Prisoner>
    {
        public void Configure(EntityTypeBuilder<Prisoner> prisoner)
        {
            prisoner.HasKey(x => x.Id);

            prisoner
                .HasOne(x => x.Cell)
                .WithMany(c => c.Prisoners)
                .HasForeignKey(x => x.CellId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
