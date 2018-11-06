using Order_Api.DTO;
using Order_Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public class ItemGroupMapper : IItemGroupMapper
    {

        public ItemGroupDTO CreateItemGroupDTOFromItemGroup(ItemGroup itemGroup)
        {
            return new ItemGroupDTO
            {
                ProductID = itemGroup.ItemId,
                Amount = itemGroup.Amount,
                ShippingDate = itemGroup.ShippingDate
            };
        }

        public ItemGroup CreateItemGroupFromItemGroupDTO(ItemGroupDTO itemGroupDTO)
        {
            return new ItemGroup
            {
                ItemId = itemGroupDTO.ProductID,
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

        public List<ItemGroupDTO> CreateItemGroupDTOFromItemGroupList(List<ItemGroup> itemGroup)
        {
            List<ItemGroupDTO> newListOfItemGroups = new List<ItemGroupDTO>();
            foreach (var item in itemGroup)
            {
                newListOfItemGroups.Add(CreateItemGroupDTOFromItemGroup(item));
            }
            return newListOfItemGroups;
        }

    }
}
