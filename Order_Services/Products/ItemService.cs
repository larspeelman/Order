using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order_Domain.Orders;
using Order_Domain.items;
using Order.Data;
using Microsoft.EntityFrameworkCore;

namespace Order_Services.items
{
    public class itemService : IitemService
    {
        private readonly OrderDbContext _context;

        public itemService(OrderDbContext context)
        {
            _context = context;
        }

        public Item AddNewitemToDatabase(Item item)
        {
            if (item == null)
            {
                return null;
            }
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public List<Item> GetAllitems()
        {
            return _context.Items.Select(it => it).ToList();
                
        }

        public Item Updateitem(Item ItemToUpdate)
        {
            var item = new Item()
            {
                ItemID = ItemToUpdate.ItemID,
            };
            _context.Attach(item);
            item.Name = ItemToUpdate.Name;
            item.Price = ItemToUpdate.Price;
            item.Description = ItemToUpdate.Description;
            item.Amount = ItemToUpdate.Amount;
            _context.SaveChanges();

            return item;
        }

        public Item Getitem(int id)
        {
            var result = _context.Items.SingleOrDefault(x => x.ItemID == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }


        public void UpdateStock(List<ItemGroup> Ordereditems)
        {
            foreach (var item in Ordereditems)
            {
                var itemInDB = Getitem(item.ItemId);
                if (itemInDB.Amount <= 0)
                {
                    itemInDB.Amount = 0;
                }
                else if (itemInDB.Amount < item.Amount)
                {
                    itemInDB.Amount = 0;
                }
                else
                {
                    itemInDB.Amount = itemInDB.Amount - item.Amount;
                }

            }
        }
    }
}
