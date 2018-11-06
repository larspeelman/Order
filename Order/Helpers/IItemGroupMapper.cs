using Order_Api.DTO;
using Order_Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public interface IItemGroupMapper
    {
        ItemGroupDTO CreateItemGroupDTOFromItemGroup(ItemGroup itemGroup);
        ItemGroup CreateItemGroupFromItemGroupDTO(ItemGroupDTO itemGroupDTO);
        List<ItemGroup> CreateItemGroupFromItemGroupDTOList(List<ItemGroupDTO> itemGroupDTO);
        List<ItemGroupDTO> CreateItemGroupDTOFromItemGroupList(List<ItemGroup> itemGroup);
    }
}
