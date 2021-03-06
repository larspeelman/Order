﻿using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Order_Services.Users
{
    public interface IUserService
    {
        User CreateNewCustomer(User customerToCreate);
        Task<User> Authenticate(string email, string password);
        IEnumerable<User> GetAllCustomers();
        User GetSingleUser(int id);
    }
}
