using System;
using Document.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Document.Inftrastructure
{
    public class CustomerDocumentConfiguration : IEntityTypeConfiguration<CustomerDocument>
    {
        public void Configure(EntityTypeBuilder<CustomerDocument> builder)
        {
            builder.HasKey(p=>p.Id);

            builder.Property(p=>p.Number)
                .IsUnicode(false)
                .IsRequired();               
        }
    }
}