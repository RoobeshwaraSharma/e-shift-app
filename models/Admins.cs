using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public class Admins : User
    {
        public string? FullName { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
