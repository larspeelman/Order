using Order.Data;
using Order_Api.Exceptions;
using Order_Domain.items;
using Order_Services.items;
using Order_Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_Domain.Orders
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;
        private readonly IitemService _itemService;
        private readonly IUserService _userService;



        public OrderClass CreateOrder(OrderClass orderedItems)
        {
            var CustomerToCheck = _userService.CheckIfCustomerIsValid(orderedItems.CustomerID);
            if (CustomerToCheck != true)
            {
                throw new UserException("No User Found");
            }
            AddPriceToItemGroup(orderedItems.ItemGroups);
            GetShippingDate(orderedItems.ItemGroups);
            _context.Orders.Add(orderedItems);
            _itemService.UpdateStock(orderedItems.ItemGroups);
            return orderedItems;
        }

        private void AddPriceToItemGroup(List<ItemGroup> Ordereditems)
        {
            List<ItemGroup> newListOfitems = new List<ItemGroup>();
            foreach (var item in Ordereditems)
            {
                var itemInDB = _itemService.Getitem(item.ItemId);
                item.Price = itemInDB.Price;
                newListOfitems.Add(item);
            }
        }

        private void GetShippingDate(List<ItemGroup> itemGroup)
        {

            foreach (var item in itemGroup)
            {
                var itemInDB = _itemService.Getitem(item.ItemId);
                item.CalculateShippingDate(itemInDB);
            }
        }


    }
}
