using Order_Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO.Orders
{
    public class ReportDTO
    {
        public List<OrderDTO_Return_Report> Orders { get; set; }
        public decimal TotalPriceOrder { get; set; }
    }
}
