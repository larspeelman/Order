using Order_Domain.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO
{
    public class ItemGroupDTO
    {
        
        public string itemID { get; set; }
        public int Amount { get; set; }
        public DateTime ShippingDate { get; set; }

    }
}
