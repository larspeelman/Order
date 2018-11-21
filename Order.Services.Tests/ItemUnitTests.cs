using NSubstitute;
using Order_Domain.Orders;
using Order_Domain.items;
using Order_Domain.Users;
using Order_Services.items;
using System;
using System.Collections.Generic;
using Xunit;

namespace Order.Services.Tests
{
    public class ItemUnitTests
    {
        Items testitem = new Items()
        {
            Amount = 1,
            Description = "test",
            ItemID = "1",
            Name = "test",
            Price = 200
        };

        [Fact]
        public void GivenAddNewitem_WhenAddingAitem_ThenReturnitem()
        {
            
            IitemRepository itemSTUB = Substitute.For<IitemRepository>();
          
            itemService itemService = new itemService(itemSTUB);
            var actual = itemService.AddNewitemToDatabase(testitem);

            Assert.IsType<Items>(actual);

        }

        [Fact]
        public void GivenUpdateitem_WhenUpdatingAitem_ThenReturnitem()
        {
            
            IitemRepository itemSTUB = Substitute.For<IitemRepository>();
          
            itemService itemService = new itemService(itemSTUB);
            var actual = itemService.AddNewitemToDatabase(testitem);

            Assert.IsType<Items>(actual);

        }

       
    }
}
