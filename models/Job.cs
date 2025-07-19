using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public enum JobStatus
    {
        Submitted = 0,
        Approved = 1,
        Rejected = 2,
        Inprogress = 3,
        Completed = 4
    }

    public class Job
    {
        public int JobId { get; set; } // Primary Key
        public int CustomerId { get; set; } // Foreign Key
        public int? TransportUnitId { get; set; } // Foreign Key (optional, if a transport unit is assigned)
        public required string StartLocation { get; set; }
        public required string EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public JobStatus Status { get; set; } = JobStatus.Submitted; // Default value
 

        // Navigation property
        public Customer? Customer { get; set; }
        public ICollection<Load>? Loads { get; set; }
        public TransportUnit? TransportUnit { get; set; }
    }
}
