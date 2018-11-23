using Microsoft.AspNetCore.Http;
using Order.Data;
using Order_Api.Exceptions;
using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Order_Services.Users
{
    public class UserService : IUserService
    {
        private readonly OrderDbContext _context;

        public UserService(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await Task.Run(() => _context.Users.SingleOrDefault(x => x.Email == email && x.Password == password));

            if (user == null)
                return null;

            return user;
        }

        public User CreateNewCustomer(User customerToCreate)
        {
            var emailAlreadyInDB = _context.Users.SingleOrDefault(x => x.Email == customerToCreate.Email);
            if (emailAlreadyInDB != null)
            {
              
                throw new UserException("Email is already in use");
            }
            else if (customerToCreate == null)
            {
                return null;
            }
            else
            {
                customerToCreate.RoleOfUserID = 2;
                _context.Users.Add(customerToCreate);
                _context.SaveChanges();
                return customerToCreate;
            }
        }

        public IEnumerable<User> GetAllCustomers()
        {

            return _context.Users.Select(x => x).ToList();
        }

        public User GetSingleUser(int id)
        {
            var result = _context.Users.SingleOrDefault(x => x.UserID == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }


    }
}
