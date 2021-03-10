using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data.Configurations
{
    public class OfficerPrisonerConfiguration : IEntityTypeConfiguration<OfficerPrisoner>
    {
        public void Configure(EntityTypeBuilder<OfficerPrisoner> officerPrisoner)
        {
            officerPrisoner.HasKey(x => new {x.OfficerId, x.PrisonerId});

            officerPrisoner
                .HasOne(x => x.Prisoner)
                .WithMany(x => x.PrisonerOfficers)
                .HasForeignKey(x => x.PrisonerId)
                .OnDelete(DeleteBehavior.Restrict);

            officerPrisoner
                .HasOne(x => x.Officer)
                .WithMany(x => x.OfficerPrisoners)
                .HasForeignKey(x => x.OfficerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
