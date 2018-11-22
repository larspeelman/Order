using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO
{
    public class UserDTO_Return
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AdressDTO Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleOfUserID { get; set; }
    }
}
