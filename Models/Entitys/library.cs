using Library_mangement_system.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<ApplicationUser> USers { get; set; } = new List<ApplicationUser>();
        public ICollection<Librian> Librarians { get; set; } = new List<Librian>();
    }
}
