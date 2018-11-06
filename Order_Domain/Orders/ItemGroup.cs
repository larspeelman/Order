using Order_Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_Domain.Orders
{
    public class ItemGroup
    {
        public string ItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime ShippingDate { get; set; }

    }
}
