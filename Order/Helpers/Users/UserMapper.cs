using Order_Api.DTO;
using Order_Api.DTO.Users;
using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public class UserMapper : IUserMapper
    {

        public UserDTO_Return CreateUserDTOReturnFromCustomer(User user)
        {
            return new UserDTO_Return
            {
                Firstname = user.Firstname,
                RoleOfUserID = user.RoleOfUserID,
                LastName = user.LastName,
                Adress = CreateAdressDTO(user.Address),
                Email = user.Email,
            };
        }

        public User CreateCustomerFromCustomerDTOCreate(UserDTO_Create userDTO)
        {
            return new User
            {
                Firstname = userDTO.Firstname,
                Password = userDTO.Password,
                LastName = userDTO.LastName,
                Address = CreateAddressFromAddressDTO(userDTO.Adress),
                Email = userDTO.Email,
            };

        }

        private AdressDTO CreateAdressDTO (Address address)
        {
            return new AdressDTO
            {
                StreetName = address.StreetName,
                PostalCode = address.PostalCode,
                Number = address.Number
            };
        }

        private Address CreateAddressFromAddressDTO(AdressDTO address)
        {
            return new Address
            {
                StreetName = address.StreetName,
                Number = address.Number,
                PostalCode = address.PostalCode
            };
        }
    }
}
