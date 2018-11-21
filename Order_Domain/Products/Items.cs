using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Products
{
    public class Items
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string ItemID { get; set; }
        public int ProductIsInStock => CheckIfProductIsInStock();
        public ItemInStock ItemInStock { get; set; }

        
        private int CheckIfProductIsInStock()
        {
            if (Amount <= 0)
            {
                return 0;
            }
                return 1;

        }
    }
}
