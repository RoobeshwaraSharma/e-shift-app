using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.models
{
    public static class Session
    {
        public static User? LoggedInUser { get; set; }
    }
}
