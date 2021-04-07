using TeisterMask.Data.Models;

namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public EmployeeTask EmployeesTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>()
                .HasKey(x => new {x.EmployeeId, x.TaskId});

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.EmployeesTasks)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(x => x.Task)
                .WithMany(x => x.EmployeesTasks)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Task>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}