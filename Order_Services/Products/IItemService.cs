using System;
using System.Collections.Generic;
using System.Text;
using Order_Domain.Orders;
using Order_Domain.items;

namespace Order_Services.items
{
    public interface IitemService
    {
        Items AddNewitemToDatabase(Items item);
        List<Items> GetAllitems();
        Items Updateitem(Items itemToCheck);
        Items Getitem(int id);
        void UpdateStock(List<ItemGroup> Ordereditems);
    }
}
