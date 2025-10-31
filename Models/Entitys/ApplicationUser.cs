using library_management_system;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_mangement_system.Models.Entitys
{
    public class ApplicationUser : IdentityUser
    {

        public DateTime? createAt { get; set; }



        // Navigation Properties in user model
        [ForeignKey("library_id")]
        public int Libraryid { get; set; }
        public Library? Library { get; set; }
        public ICollection<BuyedBooks> BuyedBooks { get; set; } = new List<BuyedBooks>();
        public ICollection<Cart>? Carts { get; set; }
        public ICollection<LibraryCard>? LibraryCard { get; set; }

    }
}

