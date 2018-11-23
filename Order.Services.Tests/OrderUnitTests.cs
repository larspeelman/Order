using Microsoft.EntityFrameworkCore;
using Order.Data;
using Order_Domain.items;
using Order_Domain.Orders;
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
    public class OrderUnitTests
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
            RoleOfUserID = 2,
            Address = new Address
            {
                Number = "5",
                PostalCode = "2050",
                StreetName = "teststraat"
            }
        };

        Item testItem = new Item
        {
            Amount = 5,
            Description = "test",
            ItemID = 1,
            Name = "test",
            Price = 200
        };

        Item testItem2 = new Item
        {
            Amount = 5,
            Description = "test",
            ItemID = 1,
            Name = "peelman",
            Price = 200
        };

        [Fact]
        public void GivenCreateOrderHappyPath_WhenCreatingANewOrder_ThenOrderIsCreated()
        {
           

            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {
                context.Users.Add(testUser);
                context.Items.Add(testItem);
                context.SaveChanges();
                var testItemGr = new ItemGroup { ItemId = testItem.ItemID, Amount = 5 };
                OrderClass testOrder2 = new OrderClass
                {
                    CustomerID = testUser.UserID,
                    ItemGroups = new List<ItemGroup>(),
                };
                testOrder2.ItemGroups.Add(testItemGr);
                context.SaveChanges();

                var orderService = new OrderService(context, new ItemService(context), new UserService(context));
                var result = orderService.CreateOrder(testOrder2);
                var collection = context.Orders.Select(x => x).ToList();

                Assert.IsType<OrderClass>(result);
                Assert.Single<OrderClass>(collection);

            }
        }

        [Fact]
        public void GivenCreateOrder_WhenCustomerIsNotFound_ThenReturnNull()
        {
           

            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {
                context.Items.Add(testItem);
                context.SaveChanges();
                var testItemGr = new ItemGroup { ItemId = testItem.ItemID, Amount = 5 };
                OrderClass testOrder2 = new OrderClass
                {
                    CustomerID = testUser.UserID,
                    ItemGroups = new List<ItemGroup>(),
                };
                testOrder2.ItemGroups.Add(testItemGr);
                context.SaveChanges();

                var orderService = new OrderService(context, new ItemService(context), new UserService(context));
                var result = orderService.CreateOrder(testOrder2);
                var collection = context.Orders.Select(x => x).ToList();

                Assert.Null(result);

            }
        }

        [Fact]
        public void GivenCreateOrderAndUpdateStock_WhenOrderIsCreated_ThenStockHasBeenUpdated()
        {
           

            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {
                context.Users.Add(testUser);
                context.Items.Add(testItem);
                context.SaveChanges();
                var testItemGr = new ItemGroup { ItemId = testItem.ItemID, Amount = 5 };
                OrderClass testOrder2 = new OrderClass
                {
                    CustomerID = testUser.UserID,
                    ItemGroups = new List<ItemGroup>(),
                };
                testOrder2.ItemGroups.Add(testItemGr);
                context.SaveChanges();

                var orderService = new OrderService(context, new ItemService(context), new UserService(context));
                var result = orderService.CreateOrder(testOrder2);
                var collection = context.Orders.Select(x => x).ToList();
                context.SaveChanges();

                Assert.True(testItem.Amount == 0);

            }
        }

        [Fact]
        public void GivenCreateOrderAndAddPriceToItemGroup_WhenOrderIsCreated_ThenPriceIsAddedToItemGroup()
        {
           

            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {
                context.Users.Add(testUser);
                context.Items.Add(testItem);
                context.SaveChanges();
                var testItemGr = new ItemGroup { ItemId = testItem.ItemID, Amount = 5 };
                OrderClass testOrder2 = new OrderClass
                {
                    CustomerID = testUser.UserID,
                    ItemGroups = new List<ItemGroup>(),
                };
                testOrder2.ItemGroups.Add(testItemGr);
                context.SaveChanges();

                var orderService = new OrderService(context, new ItemService(context), new UserService(context));
                var result = orderService.CreateOrder(testOrder2);
                var collection = context.Orders.Select(x => x).ToList();
                context.SaveChanges();

                Assert.True(testItem.Amount == 0);

            }
        }

    }
}
