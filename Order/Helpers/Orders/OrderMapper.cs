using Order_Api.DTO;
using Order_Api.DTO.Orders;
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

        public OrderDTO_Return CreateOrderDTOReturnFromOrder(OrderClass order)
        {
            return new OrderDTO_Return
            {
                CustomerID = order.CustomerID,
                TotalPrice = order.TotalPrice,
                ItemGroups = _itemGroupMapper.CreateItemGroupDTOReturnFromItemGroupList(order.ItemGroups),
                OrderDate = order.OrderDate,
                OrderID = order.OrderID
            };
        }

        public OrderClass CreateOrderFromOrderDTOCreate(OrderDTO_Create orderDTO)
        {
            return new OrderClass
            {
                CustomerID = orderDTO.CustomerID,
                ItemGroups = _itemGroupMapper.CreateItemGroupFromItemGroupDTOList(orderDTO.ItemGroupDTO),

            };
        }
    }
}
