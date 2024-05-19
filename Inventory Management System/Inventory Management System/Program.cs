using Inventory_Management_System.Repositories.Interfaces;
using Inventory_Management_System.Repositories.Adaptors;
using System;
using Microsoft.Extensions.DependencyInjection;
using Inventory_Management_System.Models;

namespace Inventory_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=========================> Inventory Management System <=========================");

            //Configure the service collection and register IInventoryRepository
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IInventoryRepository, InventoryRepository>()
            .BuildServiceProvider();

            // Retrieve an instance of IInventoryRepository
            var inventoryRepository = serviceProvider.GetService<IInventoryRepository>();

            //Adding Dummy Data in List.
            inventoryRepository.Add(new Item() { Name = "Laptop", Price = 32000, Quantity = 54 });
            inventoryRepository.Add(new Item() { Name = "Mobile", Price = 11000, Quantity = 110 });
            inventoryRepository.Add(new Item() { Name = "Pendrive", Price = 350, Quantity = 20 });

            //Showing Nav bar on console
            Inventory inventory = new Inventory();
            inventory.MenuBar(inventoryRepository);
        }
    }
}
