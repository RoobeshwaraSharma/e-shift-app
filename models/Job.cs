using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public class Job
    {
        public int JobId { get; set; } // Primary Key
        public int CustomerId { get; set; } // Foreign Key
        public required string StartLocation { get; set; }
        public required string EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation property
        public Customer? Customer { get; set; }
        public ICollection<Load>? Loads { get; set; }
    }
}
