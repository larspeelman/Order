using System;
using System.Collections.Generic;
using System.Text;
using Order_Domain.Orders;
using Order_Domain.items;

namespace Order_Services.items
{
    public interface IitemService
    {
        Item AddNewitemToDatabase(Item item);
        List<Item> GetAllitems();
        Item UpdateItem(Item itemToCheck);
        Item GetSingleItem(int id);
        void UpdateStock(List<ItemGroup> Ordereditems);
    }
}
