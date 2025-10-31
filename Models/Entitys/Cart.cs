using System.ComponentModel.DataAnnotations.Schema;

namespace Library_mangement_system.Models.Entitys
{
    public class Cart
    {
        public  int CartId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public  string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<CartItems> CartItems { get; set; }


    }
}
