using Library_mangement_system.Models.Entitys;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace library_management_system
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*")]
        public string Author { get; set; }

        public int Year { get; set; }

        public bool IsAvailable { get; set; } = true;
        public string url_image { get; set; }

        [DefaultValue (100)]
        public decimal Price { get; set; } 


        [Required(ErrorMessage = "*")]
        public int LibraryId { get; set; }   // must be Required

        public Library? Library { get; set; }  // Nullable and not Required
        public ICollection<BuyedBooks> BuyedBooks { get; set; } = new List<BuyedBooks>();
        public ICollection<CartItems>? CartItems { get; set; } 
        public ICollection<OrderItems>? OrderItems { get; set; }


    }
}