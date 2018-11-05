using Order_Api.DTO;
using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public interface IUserMapper
    {
        UserDTO CreateUserDTOFromCustomer(User user);
        User CreateCustomerFromCustomerDTO(UserDTO userDTO);
    }
}
