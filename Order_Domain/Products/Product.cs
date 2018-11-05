using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Products
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string ID { get; }
        public bool ProductIsInStock => CheckIfProductIsInStock();

        public Product()
        {
            ID = CreateProductID();
         
            
        }

        private string CreateProductID()
        {
            return (ProductDB.DBProducts.Count + 1).ToString();
        }
        
        private bool CheckIfProductIsInStock()
        {
            if (Amount <= 0)
            {
                return false;
            }
                return true;

        }
    }
}
