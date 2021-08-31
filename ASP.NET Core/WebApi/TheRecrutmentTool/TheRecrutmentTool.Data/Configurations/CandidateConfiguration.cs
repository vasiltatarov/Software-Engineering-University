namespace TheRecrutmentTool.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> candidate)
        {
            candidate
                .HasOne(x => x.Recruiter)
                .WithMany(x => x.Candidates)
                .HasForeignKey(x => x.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
