using System;
using System.Collections.Generic;
using System.Text;
using Order_Domain.Orders;
using Order_Domain.Products;

namespace Order_Services.Products
{
    public interface IProductService
    {
        Product AddNewProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product UpdateProduct(int id, Product productToCheck);
        Product GetProduct(string id);
        void UpdateStock(List<ItemGroup> OrderedProducts);
    }
}
