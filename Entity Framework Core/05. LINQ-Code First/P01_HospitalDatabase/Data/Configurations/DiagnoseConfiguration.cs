using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.Configurations
{
    public class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> diagnose)
        {
            diagnose.HasKey(d => d.DiagnoseId);


            diagnose.Property(v => v.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            diagnose.Property(v => v.Comments)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(250);

            diagnose
                .HasOne(d => d.Patient)
                .WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
