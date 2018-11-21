using Order_Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_Domain.Orders
{
    public class ItemGroup
    {

        public string ItemId { get; set; }
        public string OrderID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime ShippingDate { get; private set; }


        private void CalculateShippingDate()
        {

                if (productInDB.ProductIsInStock == false || productInDB.Amount - Amount <= 0)
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
