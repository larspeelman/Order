using Order_Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO.Orders
{
    public class OrderDTO_Return
    {
        public string CustomerID { get; set; }
        public List<ItemGroupDTO> ItemGroups { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
