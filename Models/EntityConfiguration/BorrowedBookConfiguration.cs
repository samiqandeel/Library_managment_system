using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system.EntityConfiguration
{
    public class BorrowedBookConfiguration : IEntityTypeConfiguration<BuyedBooks>
    {
        public void Configure(EntityTypeBuilder<BuyedBooks> builder)
        {
            builder.HasKey(bb => bb.Id);

        
            // Relationships
            builder.HasOne(bb => bb.User)
                .WithMany(u => u.BuyedBooks)
                .HasForeignKey(bb => bb.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(bb => bb.Book)
                .WithMany(b => b.BuyedBooks)
                .HasForeignKey(bb => bb.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Composite Index
            builder.HasIndex(bb => new { bb.UserId, bb.BookId, bb.BuyDate });
        }
    }
}
