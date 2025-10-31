using library_management_system;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_mangement_system.Models.Entitys
{
    public class OrderItems
    {
        public int OrderItemsID { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public string Titel { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
