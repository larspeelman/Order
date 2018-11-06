using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Domain.Orders
{
    public interface IOrderService
    {
        OrderClass CreateOrder(OrderClass OrderedProducts);
    }
}
