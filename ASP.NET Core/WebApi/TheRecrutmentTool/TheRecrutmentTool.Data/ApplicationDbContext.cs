namespace TheRecrutmentTool.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Configurations;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<CandidateSkill> CandidateSkills { get; set; }

        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobSkill> JobSkills { get; set; }

        public DbSet<Interview> Interviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateSkillConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new JobSkillConfiguration());
            modelBuilder.ApplyConfiguration(new InterviewConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
