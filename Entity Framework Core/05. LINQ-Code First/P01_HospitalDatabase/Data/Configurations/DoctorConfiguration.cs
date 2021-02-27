using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> doctor)
        {
            doctor.HasKey(d => d.DoctorId);

            doctor.Property(d => d.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            doctor.Property(d => d.Specialty)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);
        }
    }
}
