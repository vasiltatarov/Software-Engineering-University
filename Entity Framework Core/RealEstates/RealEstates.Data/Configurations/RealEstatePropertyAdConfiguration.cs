using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstates.Models;

namespace RealEstates.Data.Configurations
{
    public class RealEstatePropertyAdConfiguration : IEntityTypeConfiguration<RealEstatePropertyAd>
    {
        public void Configure(EntityTypeBuilder<RealEstatePropertyAd> property)
        {
            property.HasKey(x => x.Id);

            property.HasOne(x => x.BuildingType)
                .WithMany(x => x.RealEstatePropertyAds)
                .HasForeignKey(x => x.BuildingTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            property.HasOne(x => x.RealEstatePropertyType)
                .WithMany(x => x.RealEstatePropertyAds)
                .HasForeignKey(x => x.RealEstatePropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            property.HasOne(x => x.District)
                .WithMany(x => x.RealEstatePropertyAds)
                .HasForeignKey(x => x.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
