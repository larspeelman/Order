using Order_Domain.Products;
using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_Domain.Orders
{
    public class OrderClass
    {
        public string CustomerID { get; set; }
        public List<ItemGroup> ItemGroups { get; set; }
        public decimal TotalPrice => CalculatetotalPrice();
        public string OrderID { get; set; }

        public OrderClass()
        {
            OrderID = CreateOrderID();
        }

        private decimal CalculatetotalPrice()
        {
            var priceInTotal = 0.00M;
            foreach (var item in ItemGroups)
            {
                priceInTotal = (item.Amount * item.Price);
                priceInTotal += priceInTotal;
            }
            
            return priceInTotal;
        }

        private string CreateOrderID()
        {
            return (OrderDB.DBOfOrder.Count + 1).ToString();
        }
    }
}
