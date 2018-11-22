using Order_Api.DTO;
using Order_Api.DTO.Products;
using Order_Domain.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public interface IItemMapper
    {
        ItemDTO_Return CreateitemDTOReturnFromitem(Item item);
        Item CreateItemFromitemDTOCreate(ItemDTO_Create itemDTOCreate);
        List<ItemDTO_Return> CreateListItemDTOReturnFromItemsList(List<Item> listOfItems);
    }
}
