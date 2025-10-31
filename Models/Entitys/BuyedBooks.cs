using Library_mangement_system.Models.Entitys;
using Microsoft.AspNetCore.Identity;

namespace library_management_system
{
    public class BuyedBooks
    {
        public int Id { get; set; }
        public DateTime BuyDate { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public int BookId { get; set; }

        // Navigation Properties
        public ApplicationUser User { get; set; } = null!;
        public Book Book { get; set; } = null!;

    }
}