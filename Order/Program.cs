using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Order_Domain.Products;
using Order_Domain.Users;

namespace Order
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitUsers();
            InitItems();
            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        private static void InitUsers()
        {
            UserDB.DBUsers.Add(new User()
            {
                Firstname = "lars",
                LastName = "peelman",
                Email = "xxxx@hotmail.com",
                Street = "test",
                PostalCode = "2050",
                Number ="53153",
                PhoneNumber="22222",
                RoleOfUser = Roles.Role.Admin,
                Password ="test123",
            });
        }

        private static void InitItems()
        {
            ProductDB.DBProducts.Add(new Product()
            {
              Name = "iphone",
              Description = "gsm",
              Price = 200.00M,
              Amount = 10,
              ID = "1"
            });
        }
    }
}
