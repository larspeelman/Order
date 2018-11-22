using Order_Domain.items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Order_Domain.Orders

{
    public class ItemGroup
    {


        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public DateTime ShippingDate { get; set; }
        public decimal Price { get; set; }
        public OrderClass Order { get; set; }


        public ItemGroup()
        {
        }

        public void CalculateShippingDate(Item itemInDB)
        {

            if (itemInDB.ItemInStock == 0 || itemInDB.Amount - Amount <= 0)
            {
                ShippingDate = DateTime.Now.AddDays(7);
            }
            else
            {
                ShippingDate = DateTime.Now.AddDays(1);
            }
        }

    }
}
