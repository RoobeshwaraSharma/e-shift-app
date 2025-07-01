using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public enum CotainerStatus
    {
        Available = 0,
        Assigned = 1,
        Maintenance = 2,
    }
    public class Container
    {
        public int Id { get; set; } // Primary Key
        public decimal Capacity { get; set; }
        public CotainerStatus Status { get; set; } = CotainerStatus.Available; // Default value

        // Navigation property
        public TransportUnit? TransportUnit { get; set; }
    }
}
