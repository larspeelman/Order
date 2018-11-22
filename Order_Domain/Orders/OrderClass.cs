using Order_Domain.items;
using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Order_Domain.Orders
{
    public class OrderClass
    {
        private decimal totalPrice;

        public int CustomerID { get; set; }
        public User User { get; set; }
        public List<ItemGroup> ItemGroups { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return CalculatetotalPrice();
            }
            set
            {
                totalPrice = value;
            }
        }

        public OrderClass()
        {
            OrderDate = GetOrderDate();
        }

        private decimal CalculatetotalPrice()
        {
            var priceInTotal = 0.00M;
            foreach (var item in ItemGroups)
            {
                var subTotal = (item.Amount * item.Price);
                priceInTotal = priceInTotal + subTotal;
            }
            
            return priceInTotal;
        }

        private DateTime GetOrderDate()
        {
            return DateTime.Now;
        }


    }
}
