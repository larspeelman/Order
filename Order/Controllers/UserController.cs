using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Api.DTO;
using Order_Api.Exceptions;
using Order_Api.Helpers;
using Order_Services.Users;

namespace Order_Api.Controllers
{

    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userservice;
        private readonly IUserMapper _userMapper;

        public UserController(IUserService userservice, IUserMapper userMapper)
        {
            _userservice = userservice;
            _userMapper = userMapper;
        }



        // GET: api/Customer
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return _userservice.GetAllCustomers().Select(user => _userMapper.CreateUserDTOFromCustomer(user));
        }

        // GET: api/Customer/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            var checkUserId = _userservice.GetAllCustomers().SingleOrDefault(x => x.ID == id.ToString());
            if (checkUserId == null)
            {
                throw new UserException("No user was found with this ID");
            }
            return _userMapper.CreateUserDTOFromCustomer(checkUserId);
            
        }

        // POST: api/Customer
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserDTO> CreateCustomer([FromBody] UserDTO customer)
        {
            if (customer != null)
            {
                var customerDTO = _userservice.CreateNewCustomer(_userMapper.CreateCustomerFromCustomerDTO(customer));
                return Ok(_userMapper.CreateUserDTOFromCustomer(customerDTO));
            }
            return BadRequest("Not all fields were filled in");

        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
