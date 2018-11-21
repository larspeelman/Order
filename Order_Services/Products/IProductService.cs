using System;
using System.Collections.Generic;
using System.Text;
using Order_Domain.Orders;
using Order_Domain.Products;

namespace Order_Services.Products
{
    public interface IProductService
    {
        Items AddNewProduct(Items product);
        IEnumerable<Items> GetAllProducts();
        Items UpdateProduct(int id, Items productToCheck);
        Items GetProduct(string id);
        void UpdateStock(List<ItemGroup> OrderedProducts);
    }
}
