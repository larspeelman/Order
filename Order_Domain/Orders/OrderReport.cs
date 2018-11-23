using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Orders
{
    public class OrderReport
    {
        public List<ItemGroup> ItemGroups { get; set; }
        public decimal TotalPriceOrder { get; set; }
        public decimal TotalPriceAllOrders { get; set; }
    }
}
