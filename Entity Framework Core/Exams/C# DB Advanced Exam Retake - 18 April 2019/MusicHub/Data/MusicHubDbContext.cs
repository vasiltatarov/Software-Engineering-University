using MusicHub.Data.Models;

namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        { }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Performer> Performers { get; set; }

        public DbSet<SongPerformer> SongsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>().HasKey(x => new {x.PerformerId, x.SongId});

            builder.Entity<SongPerformer>()
                .HasOne(x => x.Performer)
                .WithMany(x => x.PerformerSongs)
                .HasForeignKey(x => x.PerformerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SongPerformer>()
                .HasOne(x => x.Song)
                .WithMany(x => x.SongPerformers)
                .HasForeignKey(x => x.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Song>()
                .HasOne(x => x.Album)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Song>()
                .HasOne(x => x.Writer)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.WriterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Album>()
                .HasOne(x => x.Producer)
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
