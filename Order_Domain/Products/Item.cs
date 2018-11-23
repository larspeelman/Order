using Order_Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.items
{
    public class Item
    {

        private  int itemIsInStockID;

        public int Amount { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public decimal Price { get;  set; }
        public int ItemID { get;  set; }
        public ItemGroup ItemGroup { get; set; }
        public ItemInStock ItemInStock => SetIdToStringForITemInStock();

        public int ItemIsInStockID
        {
            get
            {
                return CheckIfitemIsInStock();
            }
            set
            {
                itemIsInStockID = value;
            }
        }

        public Item()
        {
        }

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
