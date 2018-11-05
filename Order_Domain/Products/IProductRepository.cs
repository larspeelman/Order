using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Products
{
    public interface IProductRepository
    {
        void AddNewProductToDB(Product product);
        IEnumerable<Product> GetAllProductsFromDB();
        void UpdateProduct(Product productToCheck);
    }
}
