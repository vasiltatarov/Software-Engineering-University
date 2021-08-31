namespace TheRecrutmentTool.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> interview)
        {
            interview
                .HasOne(x => x.Job)
                .WithMany(x => x.Interviews)
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.Restrict);

            interview
                .HasOne(x => x.Candidate)
                .WithMany(x => x.Interviews)
                .HasForeignKey(x => x.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
