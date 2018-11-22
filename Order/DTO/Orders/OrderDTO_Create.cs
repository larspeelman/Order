using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO
{
    public class OrderDTO_Create
    {
        public int CustomerID { get; set; }
        public List<ItemGroupDTO> ItemGroupDTO { get; set; }

    }
}
