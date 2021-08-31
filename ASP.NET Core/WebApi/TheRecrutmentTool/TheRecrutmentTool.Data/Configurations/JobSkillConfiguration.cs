namespace TheRecrutmentTool.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class JobSkillConfiguration : IEntityTypeConfiguration<JobSkill>
    {
        public void Configure(EntityTypeBuilder<JobSkill> jobSkill)
        {
            jobSkill
                .HasKey(x => new { x.JobId, x.SkillId });

            jobSkill
                .HasOne(x => x.Job)
                .WithMany(x => x.Skills)
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            jobSkill
                .HasOne(x => x.Skill)
                .WithMany(x => x.JobSkills)
                .HasForeignKey(x => x.SkillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
