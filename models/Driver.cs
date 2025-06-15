using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public class Driver
    {
        public int Id { get; set; } // Primary Key
        public required string Name { get; set; }
        public required string LicenseNumber { get; set; }

        // Navigation property
        public TransportUnit? TransportUnit { get; set; }
    }
}
