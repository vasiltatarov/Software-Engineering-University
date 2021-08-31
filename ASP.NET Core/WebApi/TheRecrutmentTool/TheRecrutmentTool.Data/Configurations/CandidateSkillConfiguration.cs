namespace TheRecrutmentTool.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CandidateSkillConfiguration : IEntityTypeConfiguration<CandidateSkill>
    {
        public void Configure(EntityTypeBuilder<CandidateSkill> candidateSkill)
        {
            candidateSkill
                .HasKey(x => new { x.CandidateId, x.SkillId });

            candidateSkill
                .HasOne(x => x.Candidate)
                .WithMany(x => x.CandidateSkills)
                .HasForeignKey(x => x.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);

            candidateSkill
                .HasOne(x => x.Skill)
                .WithMany(x => x.CandidateSkills)
                .HasForeignKey(x => x.SkillId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
