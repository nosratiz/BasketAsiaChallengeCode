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

        builder.Property(e => e.Email)
            .IsRequired().HasMaxLength(254);

        builder.HasIndex(e => e.Email).IsUnique();


        builder.Property(e => e.BankAccountNumber)
            .IsRequired()
            .HasMaxLength(18);


        builder.Property(e => e.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);


        builder.Property(e => e.DateOfBirth)
            .IsRequired();
        
        
        builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth })
            .IsUnique();



    }
}