using Microsoft.AspNetCore.Http;
using Order_Api.Exceptions;
using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Order_Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await Task.Run(() => _userRepository.GetAllCustomers().SingleOrDefault(x => x.Email == email && x.Password == password));

            if (user == null)
                return null;

            return user;
        }

        public User CreateNewCustomer(User customerToCreate)
        {
            var emailAlreadyInDB = _userRepository.GetAllCustomers().SingleOrDefault(x => x.Email == customerToCreate.Email);
            if (emailAlreadyInDB != null)
            {
              
                throw new UserException("Email is already in use");
            }
            else
            {
                customerToCreate.RoleOfUser = Roles.Role.Customer;
                _userRepository.AddCustomerToDB(customerToCreate);
                return customerToCreate;
            }
        }

        public IEnumerable<User> GetAllCustomers()
        {

            return _userRepository.GetAllCustomers();
        }

        public bool CheckIfCustomerIsValid(string id)
        {
            var customerInDB = _userRepository.GetAllCustomers().SingleOrDefault(x => x.ID == id);
            if (customerInDB == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



    }
}
