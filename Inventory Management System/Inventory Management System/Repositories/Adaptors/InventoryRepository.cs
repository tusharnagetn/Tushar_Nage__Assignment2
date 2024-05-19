
using Inventory_Management_System.Models;
using Inventory_Management_System.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Inventory_Management_System.Repositories.Adaptors
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly List<Item> items;

        public InventoryRepository() 
        {
            items = new List<Item>();
        }
        public void Add(Item item)
        {
            var GetGreaterIditem = items.OrderByDescending(x => x.Id).FirstOrDefault();
            if (GetGreaterIditem != null)
            {
                item.Id = GetGreaterIditem.Id + 1;
            }
            else
            {
                item.Id = 1;
            }
            items.Add(item);
        }

        public List<Item> GetAll()
        {
            return items;
        }

        public Item GetById(int id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        public bool Remove(int id)
        {
            var ToRemove = GetById(id);

            if (ToRemove != null)
            {
                items.Remove(ToRemove);
                return true;
            }

            return false;
        }

        public void Update(Item Updateditem)
        {
            var item = GetById(Updateditem.Id);
            if (item != null)
            {
                item.Name = Updateditem.Name;
                item.Price = Updateditem.Price;
                item.Quantity = Updateditem.Quantity;
            }
        }
    }
}
