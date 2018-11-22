using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Order_Domain.Users
{
    public class User
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public Role Roles { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public int RoleOfUserID { get; set; }

        public User()
        {
        }
    }
}
