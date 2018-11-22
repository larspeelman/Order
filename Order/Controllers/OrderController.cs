using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Api.DTO;
using Order_Api.DTO.Orders;
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

        // POST: api/Order
        [Authorize (Policy =  "Customer")]
        [HttpPost]
        public ActionResult<OrderDTO_Return> CreateOrder([FromBody] OrderDTO_Create orderedItems)
        {
            var result = _orderService.CreateOrder(_ordermapper.CreateOrderFromOrderDTOCreate(orderedItems));
            if (result == null)
            {
                return BadRequest("No items to order");
            }
            else
            {
                return Ok(_ordermapper.CreateOrderDTOReturnFromOrder(result));
            }
        }

        [Authorize (Policy = "Customer")]
        [Route("api/order/customerID")]
        [HttpGet]
        public ActionResult<ReportDTO> CreateReportForCustomer(int customerID)
        {
            return null;
        }

    }
}
