﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO
{
    public class OrderDTOWithoutTotalPrice
    {

            public string CustomerID { get; set; }
            public List<ItemGroupDTO> ItemGroupDTO { get; set; }

    }
}
