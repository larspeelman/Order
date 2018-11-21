using Order_Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.items
{
    public class Items
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public decimal Price { get;  set; }
        public int Amount { get;  set; }
        public int ItemID { get;  set; }
        public ItemGroup ItemGroup { get; set; }
        public int ItemIsInStockID => CheckIfitemIsInStock();
        public ItemInStock ItemInStock => SetIdToStringForITemInStock();



        private int CheckIfitemIsInStock()
        {
            return Amount <= 0 ? 0 : 1;
        }

        private ItemInStock SetIdToStringForITemInStock()
        {
            if (ItemIsInStockID == 0)
            {
                return ItemInStock.OutOfStock;
            }
            else
            {
                return ItemInStock.InStock;
            }
                
        }
    }
}
