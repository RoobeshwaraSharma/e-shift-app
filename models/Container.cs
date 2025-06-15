using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public class Container
    {
        public int Id { get; set; } // Primary Key
        public decimal Capacity { get; set; }

        // Navigation property
        public TransportUnit? TransportUnit { get; set; }
    }
}
