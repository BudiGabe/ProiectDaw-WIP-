using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAW_Lab2_Sgr15.Models
{
    public class UserRole: IdentityUserRole<int>
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
