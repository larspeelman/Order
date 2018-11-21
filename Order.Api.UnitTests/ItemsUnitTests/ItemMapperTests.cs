using Order_Api.DTO.Products;
using Order_Api.Helpers;
using Order_Domain.items;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Order.Api.UnitTests.ItemsUnitTests
{
    public class ItemMapperTests
    {
        [Fact]
        public void GivenCreateitemDTOReturnFromitem_WhenGivenAnItem_ThenCreateItemDTOReturn()
        {
            var stubMap = new ItemMapper();
            var newItem = new Items
            {
                Amount = 5,
                Description = "test",
                Name = "appel",
                Price = 5.00m,
            };

            var result = stubMap.CreateitemDTOReturnFromitem(newItem);
            Assert.IsType<ItemDTO_Return>(result);
            
        }
    }
}
