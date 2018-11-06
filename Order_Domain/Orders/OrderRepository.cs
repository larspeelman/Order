using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Orders
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrderToDB(OrderClass orderedProducts)
        {
            OrderDB.DBOfOrder.Add(orderedProducts);
        }
    }
}
