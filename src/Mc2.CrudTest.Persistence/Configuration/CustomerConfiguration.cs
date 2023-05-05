using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(150);

        builder.OwnsOne(c => c.Email, e =>
        {
            e.Property(p => p.Value)
                .HasColumnName("Email")
                .HasMaxLength(254);
        });

        builder.OwnsOne(c => c.PhoneNumber, p =>
        {
            p.Property(p => p.Value)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(20);
        });


        builder.Property(e => e.BankAccountNumber)
            .IsRequired()
            .HasMaxLength(18);
        


        builder.Property(e => e.DateOfBirth)
            .IsRequired();
        
        
        builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth })
            .IsUnique();



    }
}