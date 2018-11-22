using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Users
{
    public class Role
    {
        public int RolesId { get; set; }
        public string RoleName { get; set; }
        public User User { get; set; }

        public Role()
        {
        }
    }
}
