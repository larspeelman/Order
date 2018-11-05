using Order_Api.DTO;
using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public class UserMapper : IUserMapper
    {

        public UserDTO CreateUserDTOFromCustomer(User user)
        {
            return new UserDTO
            {
                Firstname = user.Firstname,
                LastName = user.LastName,
                Adress = CreateAdressDTO(user),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public User CreateCustomerFromCustomerDTO(UserDTO userDTO)
        {
            return new User
            {
                Firstname = userDTO.Firstname,
                LastName = userDTO.LastName,
                Street = userDTO.Adress.StreetName,
                Number = userDTO.Adress.Number,
                PostalCode = userDTO.Adress.PostalCode,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
            };

        }

        private AdressDTO CreateAdressDTO (User user)
        {
            return new AdressDTO
            {
                StreetName = user.Street,
                PostalCode = user.PostalCode,
                Number = user.Number,
            };
        }
    }
}
