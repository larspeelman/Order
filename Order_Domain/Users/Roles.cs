using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Users
{
    public class Roles
    {
        public int RolesId { get; set; }
        public RolesEnum Role { get; set; }
        public User User { get; set; }
    }
}
