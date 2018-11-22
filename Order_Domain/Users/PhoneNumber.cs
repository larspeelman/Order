using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Users
{
    public class PhoneNumber
    {
        public int UserID { get; set; }
        public string Number { get; set; }
        public User User { get; set; }

        public PhoneNumber()
        {
        }
    }
}
