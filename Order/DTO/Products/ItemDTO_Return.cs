using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO.Products
{
    public class ItemDTO_Return
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int ID { get; set; }
        public int ItemIsInStock { get; set; }
    }
}
