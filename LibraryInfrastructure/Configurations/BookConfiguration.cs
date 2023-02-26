using System;
using System.Collections.Generic;
using System.Text;
using LibraryInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryInfrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Cover).IsRequired();
            builder.Property(b => b.Content).IsRequired();
            builder.Property(b => b.Genre).IsRequired();
            builder.Property(b => b.Author).IsRequired();
        }
    }
}
