using System;
using System.Collections.Generic;
using System.Text;
using Order_Domain.Products;

namespace Order_Services.Products
{
    public interface IProductService
    {
        Product AddNewProduct(Product product);
        IEnumerable<Product> GetAllProduct();
        Product UpdateProduct(int id, Product productToCheck);
    }
}
