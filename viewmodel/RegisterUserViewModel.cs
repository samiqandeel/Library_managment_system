using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_mangement_system.viewmodel
{
    public class RegisterUserViewModel
    {
        [Required]
        public  string Email { get; set; }
        [Required]
        public  string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public  string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirmed Password")]
        [Compare("Password")]
        public  string Confirmedpassword { get; set; }
        public  int Address { get; set; }

    }
}
