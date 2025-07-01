using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public enum AssistantStatus
    {
        Available = 0,
        Assigned = 1,
        OnLeave = 2,
    }
    public class Assistant
    {
        public int Id { get; set; } // Primary Key
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public AssistantStatus Status { get; set; } = AssistantStatus.Available; // Default value

        // Navigation property
        public TransportUnit? TransportUnit { get; set; }
    }
}
