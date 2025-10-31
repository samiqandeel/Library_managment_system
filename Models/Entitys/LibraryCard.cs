using Library_mangement_system.Models.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system
{
    public class LibraryCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; }
        public string UserId { get; set; }

        // Navigation Properties
        public ApplicationUser User { get; set; } = null!;
    }
}
