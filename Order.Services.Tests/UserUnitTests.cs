using Microsoft.EntityFrameworkCore;
using Order.Data;
using Order_Api.Exceptions;
using Order_Domain.Users;
using Order_Services.items;
using Order_Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Order.Services.Tests
{
    public class UserUnitTests
    {

        private static DbContextOptions CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<OrderDbContext>()
                .UseInMemoryDatabase("OrderDb" + Guid.NewGuid().ToString("N"))
                .Options;
        }

        User testUser = new User
        {
            Firstname = "lars",
            LastName = "peelman",
            Email = "lars@test.be",
            Password = "test",
            Address = new Address
            {
                Number = "5",
                PostalCode = "2050",
                StreetName = "teststraat"
            }
        };

        User testUser2 = new User
        {
            Firstname = "dave",
            LastName = "davidson",
            Email = "dave@test.be",
            Password = "test",
            Address = new Address
            {
                Number = "5",
                PostalCode = "2050",
                StreetName = "teststraat"
            }
        };

        [Fact]
        public void GivenCreateNewUser_WhenCreatingANewUser_ThenUserIsReturned()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {

                var userService = new UserService(context);
                var result = userService.CreateNewCustomer(testUser);

                Assert.IsType<User>(result);

            }
        }

        [Fact]
        public void GivenCreateNewUser_WhenCreatingANewUserWhoIsAlreadyInDatabase_ThenReturnException()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {

                var userService = new UserService(context);
                context.Add(testUser);
                context.SaveChanges();

                var ex = Assert.Throws<UserException>(() => userService.CreateNewCustomer(testUser));
                Assert.Equal("Email is already in use", ex.Message);


            }
        }

        [Fact]
        public void GivenCreateNewUser_WhenCreatingANewCustomer_ThenRoleMustBeSetToCustomer()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {

                var userService = new UserService(context);

                var result = userService.CreateNewCustomer(testUser);

                Assert.True(testUser.RoleOfUserID == 2);


            }
        }

        [Fact]
        public void GivenGetAllUsers_WhenGettingAllUsers_ThenReturnListOfAllUsers()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {

                var userService = new UserService(context);
                var result = userService.GetAllCustomers();

                var result2 = userService.GetAllCustomers().Count();
                var dbCount = context.Users.Count();

                Assert.IsType<List<User>>(result);
                Assert.True(result2 == dbCount);

            }
        }

        [Fact]
        public void GivenGetSingleUser_WhenRequestingOneUser_ThenUserIsReturned()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {
                var userService = new UserService(context);
                context.Add(testUser);
                context.SaveChanges();
                var result = userService.GetSingleUser(testUser.UserID);

                Assert.Same(testUser, result);

            }
        }

        [Fact]
        public void GivenGetSingleUser_WhenRequestingUserNotInDatabase_ThenReturnNull()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {
                var userService = new UserService(context);
                var result = userService.GetSingleUser(testUser.UserID);

                Assert.Null(result);

            }
        }

    }
}
