using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Api.DTO;
using Order_Api.DTO.Products;
using Order_Api.Helpers;
using Order_Services.items;

namespace Order_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemMapper _itemMapper;
        private readonly IitemService _itemService;

        public ItemController(IItemMapper itemMapper, IitemService itemService)
        {
            _itemMapper = itemMapper;
            _itemService = itemService;
        }



        // GET: api/item
        [HttpGet]
        public List<ItemDTO_Return> GetAllItems()
        {
            var items = _itemService.GetAllitems();
            return _itemMapper.CreateListItemDTOReturnFromItemsList(items);
        }

        // GET: api/item/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<ItemDTO_Return> GetSingleItem(int id)
        {
            var result = _itemService.Getitem(id);
            if (result == null)
            {
                return BadRequest("Item Was not Found");
            }
            else
            {
                return _itemMapper.CreateitemDTOReturnFromitem(result);
            }
        }

        // POST: api/item
        [Authorize (Roles = "Admin") ]
        [HttpPost]
        public ActionResult<ItemDTO_Return> AddNewitem([FromBody] ItemDTO_Create newitem)
        {
            var result = _itemService.AddNewitemToDatabase(_itemMapper.CreateItemFromitemDTOCreate(newitem));
            if (result == null)
            {
                return BadRequest("please fill in all required fields");
            }
            else
            {
                return Ok(_itemMapper.CreateitemDTOReturnFromitem(result));
            }
            
        }

        // PUT: api/item/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult<ItemDTO_Return> UpdateItem(int id, [FromBody] ItemDTO_Create newitem)
        {
            var itemToCheck = _itemService.Getitem(id);
            if (itemToCheck == null)
            {
                return BadRequest("item doesn't exist");
            }
            else
            {
                var updatedItem = _itemService.Updateitem(_itemMapper.CreateItemFromitemDTOCreate(newitem));
                return _itemMapper.CreateitemDTOReturnFromitem(itemToCheck);
            }
        }


    }
}
