using Order_Domain.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_Domain.Orders

{
    public class ItemGroup
    {


        public int ItemId { get; set; }
        public Items Item { get; set; }
        public string OrderID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public OrderClass Order { get; set; }
        public DateTime ShippingDate { get; set; }


        public DateTime CalculateShippingDate(Items itemInDB)
        {

            if (itemInDB.ItemInStock == 0 || itemInDB.Amount - Amount <= 0)
            {
                return DateTime.Now.AddDays(7);
            }
            else
            {
                return DateTime.Now.AddDays(1);
            }
        }

    }
}
