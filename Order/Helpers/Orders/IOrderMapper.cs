using Order_Api.DTO;
using Order_Api.DTO.Orders;
using Order_Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_Api.Helpers
{
    public interface IOrderMapper
    {
        OrderDTO_Return CreateOrderDTOReturnFromOrder(OrderClass order);
        OrderClass CreateOrderFromOrderDTOCreate(OrderDTO_Create orderDTO);
    }
}
