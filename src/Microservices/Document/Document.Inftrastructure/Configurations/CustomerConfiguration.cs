 using System;
using Document.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Document.Inftrastructure
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p=>p.Id);

            builder.Property(p=>p.FirstName)
                .HasMaxLength(50);

            builder.Property(p=>p.LastName)
                .HasMaxLength(50)
                .IsRequired();
                
        }
    }
}