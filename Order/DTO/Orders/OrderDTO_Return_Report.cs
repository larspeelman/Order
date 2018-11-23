using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO.Orders
{
    public class OrderDTO_Return_Report
    {
        public List<ItemGroupDTO_Return> ItemGroups { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
    }
}
