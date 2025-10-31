using library_management_system;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_mangement_system.Models.Entitys
{
    public class CartItems
    {
        public int CartItemsId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        [ForeignKey("Cart")]
        public int CartId { get; set; }

        public Cart? Cart { get; set; }
        public Book? Book { get; set; }
    }
}
