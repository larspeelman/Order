using Order_Api.DTO;
using Order_Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public interface IProductMapper
    {
        ProductDTO CreateProductDTOFromProduct(Items product);
        Items CreateProductFromProductDTO(ProductDTO productDTO);
    }
}
