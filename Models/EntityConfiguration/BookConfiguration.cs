using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system.EntityConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            // Primary Key
            builder.HasKey(b => b.Id);

            // Properties Configuration
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(b => b.Year)
                .IsRequired();

            builder.Property(b => b.IsAvailable)
                .HasDefaultValue(true);

            builder.Property(b => b.Price)
                .HasDefaultValue(100m);
           
            // Relationships
            builder.HasOne(b => b.Library)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LibraryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Index for better performance
            builder.HasIndex(b => b.Title);
        }
    }
}
