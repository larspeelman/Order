using NSubstitute;
using Order_Domain.Orders;
using Order_Domain.Products;
using Order_Domain.Users;
using Order_Services.Products;
using System;
using System.Collections.Generic;
using Xunit;

namespace Order.Services.Tests
{
    public class ItemUnitTests
    {
        Items testProduct = new Items()
        {
            Amount = 1,
            Description = "test",
            ItemID = "1",
            Name = "test",
            Price = 200
        };

        [Fact]
        public void GivenAddNewProduct_WhenAddingAProduct_ThenReturnProduct()
        {
            
            IProductRepository productSTUB = Substitute.For<IProductRepository>();
          
            ProductService productService = new ProductService(productSTUB);
            var actual = productService.AddNewProduct(testProduct);

            Assert.IsType<Items>(actual);

        }

        [Fact]
        public void GivenUpdateProduct_WhenUpdatingAProduct_ThenReturnProduct()
        {
            
            IProductRepository productSTUB = Substitute.For<IProductRepository>();
          
            ProductService productService = new ProductService(productSTUB);
            var actual = productService.AddNewProduct(testProduct);

            Assert.IsType<Items>(actual);

        }

       
    }
}
