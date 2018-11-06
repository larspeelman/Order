using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order_Domain.Orders;
using Order_Domain.Products;

namespace Order_Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product AddNewProduct(Product product)
        {
            _productRepository.AddNewProductToDB(product);
            return product;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _productRepository.GetAllProductsFromDB();
        }

        public Product UpdateProduct(int id, Product productToCheck)
        {
            _productRepository.UpdateProduct(productToCheck);
            return productToCheck;
        }

        public Product GetProduct(string id)
        {
            return _productRepository.GetAllProductsFromDB().SingleOrDefault(x => x.ID == id);
        }


        public void UpdateStock(List<ItemGroup> OrderedProducts)
        {
            foreach (var item in OrderedProducts)
            {
                var productInDB = _productRepository.GetAllProductsFromDB().SingleOrDefault(x => x.ID == item.ItemId);
                if (productInDB.Amount <= 0)
                {
                    productInDB.Amount = 0;
                }
                else if (productInDB.Amount < item.Amount)
                {
                    productInDB.Amount = 0;
                }
                else
                {
                    productInDB.Amount = productInDB.Amount - item.Amount;
                }

            }
        }
    }
}
