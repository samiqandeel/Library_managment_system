using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system.EntityConfiguration
{
    // تكوين كيان أمين المكتبة
    public class LibrarianConfiguration : IEntityTypeConfiguration<Librian>
    {
        public void Configure(EntityTypeBuilder<Librian> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.EmployeeNumber)
                .IsRequired();

            builder.HasIndex(l => l.EmployeeNumber)
                .IsUnique(); 

            // Relationship
            builder.HasOne(l => l.Library)
                .WithMany(lib => lib.Librarians)
                .HasForeignKey(l => l.LibraryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
