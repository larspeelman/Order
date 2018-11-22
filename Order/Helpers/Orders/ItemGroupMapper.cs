using Order_Api.DTO;
using Order_Api.DTO.Orders;
using Order_Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public class ItemGroupMapper : IItemGroupMapper
    {

        public ItemGroupDTO_Return CreateItemGroupDTOReturnFromItemGroup(ItemGroup itemGroup)
        {
            return new ItemGroupDTO_Return
            {
                ItemID = itemGroup.ItemId,
                Amount = itemGroup.Amount,
                ShippingDate = itemGroup.ShippingDate
            };
        }

        public ItemGroup CreateItemGroupFromItemGroupDTO(ItemGroupDTO itemGroupDTO)
        {
            return new ItemGroup
            {
                ItemId = itemGroupDTO.ItemID,
                Amount = itemGroupDTO.Amount,
            };
        }

        public List<ItemGroup> CreateItemGroupFromItemGroupDTOList(List<ItemGroupDTO> itemGroupDTO)
        {
            List<ItemGroup> newListOfItemGroups = new List<ItemGroup>();
            foreach (var item in itemGroupDTO)
            {
                newListOfItemGroups.Add(CreateItemGroupFromItemGroupDTO(item));
            }
            return newListOfItemGroups;
        }

        public List<ItemGroupDTO_Return> CreateItemGroupDTOReturnFromItemGroupList(List<ItemGroup> itemGroup)
        {
            List<ItemGroupDTO_Return> newListOfItemGroups = new List<ItemGroupDTO_Return>();
            foreach (var item in itemGroup)
            {
                newListOfItemGroups.Add(CreateItemGroupDTOReturnFromItemGroup(item));
            }
            return newListOfItemGroups;
        }

    }
}
