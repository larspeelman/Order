using Order_Domain.Products;
using Order_Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_Domain.Orders
{
    public class Order
    {
        public User Customer => ReturnCustomerForOrder();
        public string CustomerID { get; set; }
        public List<Product> ProductGroups { get; set; }
        public decimal TotalPrice => CalculatetotalPrice();

        private User ReturnCustomerForOrder()
        {
            return UserDB.DBUsers.SingleOrDefault(x => x.ID == CustomerID);
        }

        private decimal CalculatetotalPrice()
        {
            return ProductGroups.Sum(x => x.Price);
        }
    }
}
