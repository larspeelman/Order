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
    public class ItemService : IitemService
    {
        private readonly OrderDbContext _context;

        public ItemService(OrderDbContext context)
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

        public Item UpdateItem(Item itemToUpdate)
        {
            var item = _context.Items.Find(itemToUpdate.ItemID);
            _context.Attach(item);
            item.Name = itemToUpdate.Name;
            item.Price = itemToUpdate.Price;
            item.Description = itemToUpdate.Description;
            item.Amount = itemToUpdate.Amount;
            _context.SaveChanges();

            return item;
        }

        public Item GetSingleItem(int id)
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
                var itemInDB = GetSingleItem(item.ItemId);
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
