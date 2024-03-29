﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> course)
        {
            course.HasKey(c => c.CourseId);

            course.Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(80);

            course.Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode(true);

            course.Property(c => c.StartDate)
                .IsRequired(true);

            course.Property(c => c.EndDate)
                .IsRequired(true);

            course.Property(c => c.Price)
                .IsRequired(true);
        }
    }
}
