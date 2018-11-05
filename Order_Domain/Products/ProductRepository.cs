using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        public void AddNewProductToDB(Product product)
        {
            ProductDB.DBProducts.Add(product);
        }

        public IEnumerable<Product> GetAllProductsFromDB()
        {
            return ProductDB.DBProducts;
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var productToCheck = ProductDB.DBProducts.SingleOrDefault(x => x.ID == updatedProduct.ID);
            productToCheck = updatedProduct;
        }
    }
}
