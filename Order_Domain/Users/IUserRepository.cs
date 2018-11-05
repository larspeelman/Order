using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Users
{
    public interface IUserRepository
    {
        void AddCustomerToDB(User customer);
        List<User> GetAllCustomers();
    }
}
