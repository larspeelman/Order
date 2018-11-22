using Order_Api.DTO;
using Order_Api.DTO.Products;
using Order_Domain.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public class ItemMapper : IItemMapper
    {
        public ItemDTO_Return CreateitemDTOReturnFromitem(Item item)
        {

            return new ItemDTO_Return
            {
                Name = item.Name,
                Description = item.Description,
                Amount = item.Amount,
                Price = item.Price,
                ID = item.ItemID,
                ItemIsInStock = item.ItemInStock.ToString()
            };
        }
        public Item CreateItemFromitemDTOCreate(ItemDTO_Create itemDTOCreate)
        {
            return new Item
            {
                Amount = itemDTOCreate.Amount,
                Description = itemDTOCreate.Description,
                Name = itemDTOCreate.Name,
                Price = itemDTOCreate.Price,

            };
        }

        public List<ItemDTO_Return> CreateListItemDTOReturnFromItemsList(List<Item> listOfItems)
            {
                List<ItemDTO_Return> listOfItemDTO = new List<ItemDTO_Return>();

                foreach (var item in listOfItems)
                {
                    listOfItemDTO.Add(CreateitemDTOReturnFromitem(item));
                }
                return listOfItemDTO;
            }
        
    }
}
