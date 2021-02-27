using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> patient)
        {
            patient.HasKey(p => p.PatientId);

            patient.Property(p => p.FirstName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            patient.Property(p => p.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            patient.Property(p => p.Address)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(250);

            patient.Property(p => p.Email)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(80);
        }
    }
}
