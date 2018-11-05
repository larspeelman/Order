using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Users
{
    public class User
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Number { get; set; }
        public string PhoneNumber { get; set; }
        public string ID { get; }
        public string Password { get; set; }
        public Roles.Role RoleOfUser {get; set;}

        public User()
        {
            ID = CreateCustomerID();
        }

        private string CreateCustomerID()
        {
            return (UserDB.DBUsers.Count + 1).ToString();
        }
    }
}
