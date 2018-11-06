using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO
{
    public class OrderDTO
    {
        public string CustomerID { get; set; }
        public List<ItemGroupDTO> ItemGroupDTO { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
