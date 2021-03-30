using VaporStore.Data.Models;

namespace VaporStore.Data
{
	using Microsoft.EntityFrameworkCore;

	public class VaporStoreDbContext : DbContext
	{
		public VaporStoreDbContext()
		{
		}

		public VaporStoreDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Game> Games { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<GameTag> GameTags { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<User> Users { get; set; }
        
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Game>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Game>()
                .HasOne(x => x.Developer)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Purchase>()
                .HasOne(x => x.Card)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.CardId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Purchase>()
                .HasOne(x => x.Game)
                .WithMany(x => x.Purchases)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<GameTag>()
                .HasKey(x => new {x.GameId, x.TagId});

            model.Entity<GameTag>()
                .HasOne(x => x.Game)
                .WithMany(x => x.GameTags)
                .HasForeignKey(x => x.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<GameTag>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.GameTags)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.Restrict);


            model.Entity<Card>()
                .HasOne(x => x.User)
                .WithMany(x => x.Cards)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
	}
}