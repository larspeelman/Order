using Order_Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO
{
    public class ItemGroupDTO
    {
        
        public string ProductID { get; set; }
        public int Amount { get; set; }
        public DateTime ShippingDate { get; set; }

    }
}
