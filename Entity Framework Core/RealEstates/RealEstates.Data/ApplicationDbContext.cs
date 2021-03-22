using Microsoft.EntityFrameworkCore;
using RealEstates.Data.Configurations;
using RealEstates.Models;

namespace RealEstates.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RealEstatePropertyAd> RealEstatePropertyAds { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<RealEstatePropertyType> RealEstatePropertyTypes { get; set; }

        public DbSet<BuildingType> BuildingTypes { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<RealEstatePropertyTag> RealEstatePropertyTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RealEstatePropertyTagConfiguration());
            modelBuilder.ApplyConfiguration(new RealEstatePropertyAdConfiguration());
        }
    }
}
