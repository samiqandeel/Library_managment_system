using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system.EntityConfiguration
{
    public class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCard>
    {
        public void Configure(EntityTypeBuilder<LibraryCard> builder)
        {
            builder.HasKey(lc => lc.Id);

            builder.Property(lc => lc.CardNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(lc => lc.CardNumber)
                .IsUnique(); 

            // One-to-One relationship with User
            builder.HasOne(lc => lc.User)
                .WithMany(u => u.LibraryCard)
                .HasForeignKey(lc => lc.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
