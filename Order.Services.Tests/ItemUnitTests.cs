using NSubstitute;
using Order_Domain.Orders;
using Order_Domain.items;
using Order_Domain.Users;
using Order_Services.items;
using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Order.Data;

namespace Order.Services.Tests
{
    public class ItemUnitTests
    {
        private static DbContextOptions CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<OrderDbContext>()
                .UseInMemoryDatabase("OrderDb" + Guid.NewGuid().ToString("N"))
                .Options;
        }

        Item testItem = new Item()
        {
            Amount = 1,
            Description = "test",
            ItemID = 1,
            Name = "test",
            Price = 200
        };

        Item testItem2 = new Item()
        {
            Amount = 1,
            Description = "test",
            ItemID = 1,
            Name = "peelman",
            Price = 200
        };

        [Fact]
        public void GivenAddNewitem_WhenAddingAnitem_ThenReturnitem()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {

                var itemService = new ItemService(context);
                var result = itemService.AddNewitemToDatabase(testItem);

                Assert.IsType<Item>(result);

            }
        }

        [Fact]
        public void GivenAddNewitem_WhenItemToAddIsNull_ThenReturnNull()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {

                var itemService = new ItemService(context);
                var result = itemService.AddNewitemToDatabase(null);

                Assert.Null(result);

            }
        }

        [Fact]
        public void GivenGetAllItems_WhenGettingAllItems_ThenReturnListOfAllItems()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {

                var itemService = new ItemService(context);
                var result = itemService.GetAllitems();

                Assert.IsType<List<Item>>(result);

            }
        }

        [Fact]
        public void GivenUpdateItem_WhenUpdatingAnItem_ThenItemIsUpdated()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {
                var itemService = new ItemService(context);
                context.Add(testItem);
                context.SaveChanges();
                testItem = itemService.UpdateItem(testItem2);

                Assert.Equal("peelman", testItem.Name);

            }
        }

        [Fact]
        public void GivenGetSingleItem_WhenRequestingOneItem_ThenItemIsReturned()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {
                var itemService = new ItemService(context);
                context.Add(testItem);
                context.SaveChanges();
                var result = itemService.GetSingleItem(testItem.ItemID);

                Assert.Same(testItem, result);

            }
        }

        [Fact]
        public void GivenGetSingleItem_WhenRequestingItemNotInDatabase_ThenReturnNull()
        {
            using (var context = new OrderDbContext(CreateNewInMemoryDatabase()))
            {
                var itemService = new ItemService(context);
                var result = itemService.GetSingleItem(testItem.ItemID);

                Assert.Null(result);

            }
        }




    }
}
