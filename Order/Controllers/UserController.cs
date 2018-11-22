using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Api.DTO;
using Order_Api.DTO.Users;
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
        [Authorize(Policy = "Admin")]
        [HttpGet]
        public IEnumerable<UserDTO_Return> Get()
        {
            return _userservice.GetAllCustomers().Select(user => _userMapper.CreateUserDTOReturnFromCustomer(user));
        }

        // GET: api/Customer/5
        [Authorize(Policy = "Admin")]
        [HttpGet("{id}")]
        public UserDTO_Return GetSingleUser(int id)
        {
            var checkUserId = _userservice.GetAllCustomers().SingleOrDefault(x => x.UserID == id);
            if (checkUserId == null)
            {
                throw new UserException("No user was found with this ID");
            }
            return _userMapper.CreateUserDTOReturnFromCustomer(checkUserId);
            
        }

        // POST: api/Customer
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserDTO_Return> CreateCustomer([FromBody] UserDTO_Create customer)
        {
            var customerDTO = _userservice.CreateNewCustomer(_userMapper.CreateCustomerFromCustomerDTOCreate(customer));
            if (customer == null)
            {
                return BadRequest("Not all fields were filled in");
                
            }
            return Ok(_userMapper.CreateUserDTOReturnFromCustomer(customerDTO));

        }

    }
}
