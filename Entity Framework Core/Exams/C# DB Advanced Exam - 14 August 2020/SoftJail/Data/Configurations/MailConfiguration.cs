using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data.Configurations
{
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> mail)
        {
            mail.HasKey(x => x.Id);

            mail.HasOne(x => x.Prisoner)
                .WithMany(x => x.Mails)
                .HasForeignKey(x => x.PrisonerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
