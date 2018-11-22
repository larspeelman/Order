using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO.Orders
{
    public class ItemGroupDTO_Return
    {
        public int ItemID { get; set; }
        public int Amount { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}
