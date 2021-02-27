using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customer)
        {
            customer.HasKey(c => c.CustomerId);

            customer.Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            customer.Property(c => c.Email)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(80);

            customer.Property(c => c.CreditCardNumber)
                .IsRequired(true);
        }
    }
}