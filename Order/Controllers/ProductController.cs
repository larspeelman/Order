using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Api.DTO;
using Order_Api.Helpers;
using Order_Services.Products;

namespace Order_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductMapper _productMapper;
        private readonly IProductService _productService;

        public ProductController(IProductMapper productMapper, IProductService productService)
        {
            _productMapper = productMapper;
            _productService = productService;
        }



        // GET: api/Product
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        [Authorize (Roles = "Admin") ]
        [HttpPost]
        public ActionResult<ProductDTO> AddNewProduct([FromBody] ProductDTO newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("please fill in all required fields");
            }
            else
            {
                var newProductDTO = _productService.AddNewProduct(_productMapper.CreateProductFromProductDTO(newProduct));
                return Ok(_productMapper.CreateProductDTOFromProduct(newProductDTO));
            }
            
        }

        // PUT: api/Product/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult<ProductDTO> UpdateProduct(int id, [FromBody] ProductDTO newProduct)
        {
            var productToCheck = _productService.GetAllProducts().SingleOrDefault(x => x.ItemID == id.ToString());
            if (productToCheck == null)
            {
                return BadRequest("Product doesn't exist");
            }
            else
            {
                return _productMapper.CreateProductDTOFromProduct(_productService.UpdateProduct(id, _productMapper.CreateProductFromProductDTO(newProduct)));
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
