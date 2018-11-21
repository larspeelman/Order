using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Api.DTO;
using Order_Api.Helpers;
using Order_Domain.Orders;
using Order_Services.Users;

namespace Order_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderMapper _ordermapper;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IOrderMapper ordermapper, IUserService userService)
        {
            _orderService = orderService;
            _ordermapper = ordermapper;
            _userService = userService;
        }



        // GET: api/Order
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // POST: api/Order
        [Authorize ( Roles = "Member")]
        [HttpPost]
        public ActionResult<OrderDTO> CreateOrder([FromBody] OrderDTOWithoutTotalPrice Ordereditems)
        {
            if (Ordereditems == null)
            {
                return BadRequest("No items to order");
            }
            else
            {
                return Ok(_ordermapper.CreateOrderDTOFromOrder(_orderService.CreateOrder(_ordermapper.CreateOrderFromOrderDTO(Ordereditems))));
            }
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void put([FromBody] List<ItemGroupDTO> itemsToOrder)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
