using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system
{
    public class Librian
    {
        public int Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public int LibraryId { get; set; }

        // Navigation Properties
        public Library Library { get; set; } = null!;
    }


}

