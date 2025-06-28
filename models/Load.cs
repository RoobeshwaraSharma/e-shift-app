using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public class Load
    {
        public int LoadId { get; set; } // Primary Key
        public int JobId { get; set; } // Foreign Key
        public int? TransportUnitId { get; set; } // Foreign Key
        public decimal Weight { get; set; }
        public string? Description { get; set; }

        // Navigation properties
        public Job? Job { get; set; }
        public TransportUnit? TransportUnit { get; set; }
    }
}
