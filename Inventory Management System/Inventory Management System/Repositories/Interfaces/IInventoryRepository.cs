using Inventory_Management_System.Models;
using System.Collections.Generic;

namespace Inventory_Management_System.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        void Add(Item item);

        void Update(Item item);

        bool Remove(int id);

        List<Item> GetAll();

        Item GetById(int id);
    }
}
