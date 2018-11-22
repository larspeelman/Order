using Order_Api.DTO;
using Order_Api.DTO.Users;
using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public interface IUserMapper
    {
        UserDTO_Return CreateUserDTOReturnFromCustomer(User user);
        User CreateCustomerFromCustomerDTOCreate(UserDTO_Create userDTO);
    }
}
