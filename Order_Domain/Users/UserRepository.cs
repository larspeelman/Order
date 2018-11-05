using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Users
{
    public class UserRepository : IUserRepository
    {
        public void AddCustomerToDB(User customer)
        {
            UserDB.DBUsers.Add(customer);
        }

        public List<User> GetAllCustomers()
        {
            return UserDB.DBUsers;
        }
    }
}
