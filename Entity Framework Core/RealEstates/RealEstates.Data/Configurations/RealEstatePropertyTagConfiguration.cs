using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstates.Models;

namespace RealEstates.Data.Configurations
{
    public class RealEstatePropertyTagConfiguration : IEntityTypeConfiguration<RealEstatePropertyTag>
    {
        public void Configure(EntityTypeBuilder<RealEstatePropertyTag> tag)
        {
            tag.HasKey(x => new {x.RealEstatePropertyAdId, x.TagId});

            tag
                .HasOne(x => x.RealEstatePropertyAd)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.RealEstatePropertyAdId)
                .OnDelete(DeleteBehavior.Restrict);

            tag
                .HasOne(x => x.Tag)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
