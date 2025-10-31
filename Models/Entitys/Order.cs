using System.ComponentModel.DataAnnotations.Schema;

namespace Library_mangement_system.Models.Entitys
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public string User_Name { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
