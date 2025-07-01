using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public enum UnitStatus
    {
        Available = 0,
        Occupied = 1,
        Maintanance = 2,
    }
    public class TransportUnit
    {
        public int Id { get; set; } // Primary Key
        public int LorryId { get; set; } // Foreign Key
        public int DriverId { get; set; } // Foreign Key
        public int AssistantId { get; set; } // Foreign Key
        public int ContainerId { get; set; } // Foreign Key
        public UnitStatus Status { get; set; } = UnitStatus.Available; // Default value


        // Navigation properties
        public Lorry? Lorry { get; set; }
        public Driver? Driver { get; set; }
        public Assistant? Assistant { get; set; }
        public Container? Container { get; set; }

        public ICollection<Load>? Loads { get; set; }
    }
}
