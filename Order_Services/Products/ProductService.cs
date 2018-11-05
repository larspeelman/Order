using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
