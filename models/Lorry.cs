using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public enum LorryStatus
    {
        Available = 0,
        Assigned = 1,
        Maintenance = 2,
    }
    public class Lorry
    {
        public int Id { get; set; } // Primary Key
        public required string Model { get; set; }
        public required string Year { get; set; }
        public required string RegistrationNumber { get; set; }
        public required decimal Capacity { get; set; }
        public LorryStatus Status { get; set; } = LorryStatus.Available; // Default value


        // Navigation property
        public TransportUnit? TransportUnit { get; set; }
    }
}
