using Order_Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.DTO
{
    public class OrderDTO
    {
        public Product ProductItem => ReturnIdForThisProduct();
        public string ProductID { get; set; }
        public int Amount { get; set; }
        public DateTime ShippingDate => CalculateShippingDate();

        private Product ReturnIdForThisProduct()
        {
            return ProductDB.DBProducts.SingleOrDefault(x => x.ID == ProductID);
        }

        private DateTime CalculateShippingDate()
        {
            
            if (ProductItem.Amount - Amount <= 0 || (ProductItem.ProductIsInStock == false))
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
