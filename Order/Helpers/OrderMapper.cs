using Order_Api.DTO;
using Order_Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public class OrderMapper : IOrderMapper
    {
        private readonly IItemGroupMapper _itemGroupMapper;

        public OrderMapper(IItemGroupMapper itemGroupMapper)
        {
            _itemGroupMapper = itemGroupMapper;
        }

        public OrderDTO CreateOrderDTOFromOrder(OrderClass order)
        {
            return new OrderDTO
            {
                CustomerID = order.CustomerID,
                TotalPrice = order.TotalPrice,
                ItemGroupDTO = _itemGroupMapper.CreateItemGroupDTOFromItemGroupList(order.ItemGroups)
                
            };
        }

        public OrderClass CreateOrderFromOrderDTO(OrderDTOWithoutTotalPrice orderDTO)
        {
            return new OrderClass
            {
                CustomerID = orderDTO.CustomerID,
                ItemGroups = _itemGroupMapper.CreateItemGroupFromItemGroupDTOList(orderDTO.ItemGroupDTO)
            };
        }
    }
}
