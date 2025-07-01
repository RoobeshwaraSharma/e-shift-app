using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public enum DriverStatus
    {
        Available = 0,
        Assigned = 1,
        OnLeave = 2,
    }
    public class Driver
    {
        public int Id { get; set; } // Primary Key
        public required string Name { get; set; }
        public required string LicenseNumber { get; set; }
        public required string PhoneNumber { get; set; }
        public DriverStatus Status { get; set; } = DriverStatus.Available; // Default value

        // Navigation property
        public TransportUnit? TransportUnit { get; set; }
    }
}
