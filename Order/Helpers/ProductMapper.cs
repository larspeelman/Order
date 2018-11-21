using Order_Api.DTO;
using Order_Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public class ProductMapper : IProductMapper
    {
        public ProductDTO CreateProductDTOFromProduct(Items product)
        {
            return new ProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                Amount = product.Amount,
                Price = product.Price,
                ProductIsInStock = product.ProductIsInStock,
                ID = product.ItemID,
            };
        }
        public Items CreateProductFromProductDTO(ProductDTO productDTO)
        {
            return new Items
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Amount = productDTO.Amount,
                Price = productDTO.Price,
            };
        }
    }
}
