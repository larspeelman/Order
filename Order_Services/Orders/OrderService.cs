using Order_Api.Exceptions;
using Order_Domain.Products;
using Order_Services.Products;
using Order_Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_Domain.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public OrderService(IOrderRepository orderRepository, IProductService productService, IUserService userService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _userService = userService;
        }

        public OrderClass CreateOrder(OrderClass OrderedProducts)
        {
            var CustomerToCheck = _userService.CheckIfCustomerIsValid(OrderedProducts.CustomerID);
            if (CustomerToCheck != true)
            {
                throw new UserException("No User Found");
            }
            AddPriceToItemGroup(OrderedProducts.ItemGroups);
            CalculateShippingDate(OrderedProducts.ItemGroups);
            _orderRepository.AddOrderToDB(OrderedProducts);
            _productService.UpdateStock(OrderedProducts.ItemGroups);
            return OrderedProducts;
        }

        private void AddPriceToItemGroup(List<ItemGroup> OrderedProducts)
        {
            List<ItemGroup> newListOfProducts = new List<ItemGroup>();
            foreach (var item in OrderedProducts)
            {
                var productInDB = _productService.GetProduct(item.ItemId);
                item.Price = productInDB.Price;
                newListOfProducts.Add(item);
            }
        }

        private void CalculateShippingDate(List<ItemGroup> OrderedProducts)
        {
            foreach (var item in OrderedProducts)
            {
                var productInDB = _productService.GetProduct(item.ItemId);
                if (productInDB.ProductIsInStock == false || productInDB.Amount - item.Amount <= 0)
                {
                    item.ShippingDate = DateTime.Now.AddDays(7);
                }
                else
                {
                    item.ShippingDate = DateTime.Now.AddDays(1);
                }
            }
        }

        
    }
}
