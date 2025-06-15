using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public class Customer : User
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public DateTime RegisteredDate { get; set; }

        // Navigation property
        public ICollection<Job>? Jobs { get; set; }
    }
}
