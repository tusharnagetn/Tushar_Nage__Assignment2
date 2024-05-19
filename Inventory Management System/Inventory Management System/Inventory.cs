using Inventory_Management_System.Models;
using Inventory_Management_System.Repositories.Interfaces;
using System;

namespace Inventory_Management_System
{
    public class Inventory
    {
        IInventoryRepository _inventoryRepository;

        public void MenuBar(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
            Console.WriteLine();
            Console.WriteLine("[1]: Add,  [2]: Remove,  [3]: Update, [4]: View All, [5]: Get by Id, [0]: Exit");

            try
            {
                int execute = Convert.ToInt32(Console.ReadLine());
                switch (execute)
                {
                    case 1:
                        AddItem();
                        break;

                    case 2:  
                        RemoveItem();
                        break;

                    case 3:  
                        UpdateItem();
                        break;

                    case 4:
                        GetAllItem();
                        break;

                    case 5:
                        GetItemById();
                        break;

                    case 0:
                        Close();
                        break;

                    default: 
                        Console.WriteLine("Invalid Input re-enter valid input"); 
                        MenuBar(inventoryRepository);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input re-enter valid input as number ");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AddItem()
        {
            
            Console.WriteLine("--------------------> Add Item <--------------------");
            Console.WriteLine("[1]: Add, [0]: Back to Menu");
            
            try
            {
                int value = Convert.ToInt32(Console.ReadLine());
                if (value == 1)
                {
                    Item item = new Item();

                    Console.Write("Enter Name of item : ");
                    item.Name = Console.ReadLine();

                    try
                    {
                        Console.Write("Enter Price of item : ");
                        item.Price = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input - Price must be a number");
                        AddItem();
                    }

                    try
                    {
                        Console.Write("Enter Quantity of item : ");
                        item.Quantity = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input - Quantity must be a number");
                        AddItem();
                    }

                    _inventoryRepository.Add(item);
                    Console.WriteLine("Item added successfully");
                    AddItem();
                }
                else if (value == 0)
                {
                    MenuBar(_inventoryRepository);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    AddItem();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input - Enter Number");
                AddItem() ;
            }
        }

        public void RemoveItem()
        {
            Console.WriteLine("--------------------> Remove Item <--------------------");
            Console.WriteLine("[1]: Remove, [0]: Back to Menu");

            try
            {
                int value = Convert.ToInt32(Console.ReadLine());
                if (value == 1)
                {

                    var Items = _inventoryRepository.GetAll();
                    Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20}", "ID", "Name", "Price", "Quantity");
                    foreach (var item in Items)
                    {
                        Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20}", item.Id, item.Name, item.Price, item.Quantity);
                    }

                    try
                    {
                        Console.Write("Enter Id of item to remove: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        if (_inventoryRepository.Remove(id))
                        {
                            Console.WriteLine("Item removed successfully");
                        }
                        else
                        {
                            Console.WriteLine("Data not fount");
                        }
                        RemoveItem();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input - Id must be a number");
                        RemoveItem();
                    }
                }
                else if (value == 0)
                {
                    MenuBar(_inventoryRepository);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    RemoveItem();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input - Enter Number");
                RemoveItem();
            }

        }

        public void UpdateItem()
        {
            Console.WriteLine("--------------------> Update Item <--------------------");
            Console.WriteLine("[1]: Update, [0]: Back to Menu");

            try
            {
                int value = Convert.ToInt32(Console.ReadLine());
                if (value == 1)
                {

                    var Items = _inventoryRepository.GetAll();
                    Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20}", "ID", "Name", "Price", "Quantity");
                    foreach (var item in Items)
                    {
                        Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20}", item.Id, item.Name, item.Price, item.Quantity);
                    }

                    try
                    {
                        Console.Write("Enter Id of item to update : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var getToUpdate = _inventoryRepository.GetById(id);
                        if (getToUpdate != null)
                        {
                            Item item = new Item();
                            item = getToUpdate;

                            Console.Write("You want update Name (Y/N) : ");
                            string rs = Console.ReadLine();
                            if (rs == "y" || rs == "Y")
                            {
                                Console.Write("Enter New Name : ");
                                item.Name = ReadLine.Read();
                            }

                            Console.Write("You want update Price (Y/N) : ");
                            string rs1 = Console.ReadLine();

                            if (rs1 == "y" || rs1 == "Y")
                            {
                                Console.Write("Enter New Price : ");
                                item.Price = Convert.ToDouble(ReadLine.Read());
                            }

                            Console.Write("You want update Quantity (Y/N) : ");
                            string rs2 = Console.ReadLine();

                            if (rs2 == "y" || rs2 == "Y")
                            {
                                Console.Write("Enter New Quantity : ");
                                item.Quantity = Convert.ToInt32(ReadLine.Read());
                            }

                            _inventoryRepository.Update(item);
                            Console.WriteLine("Item updated successfully");
                            UpdateItem();
                        }
                        else
                        {
                            Console.WriteLine("Data not fount");
                            UpdateItem();
                        }

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input");
                        UpdateItem();
                    }
                }
                else if (value == 0)
                {
                    MenuBar(_inventoryRepository);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    UpdateItem();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input - Enter Number");
                UpdateItem();
            }
        }

        public void GetAllItem()
        {
            var Items = _inventoryRepository.GetAll();
            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20}", "ID", "Name", "Price", "Quantity");
            foreach (var item in Items)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20}", item.Id, item.Name, item.Price, item.Quantity);
            }
            MenuBar(_inventoryRepository);
        }

        public void GetItemById()
        {
            Console.WriteLine("--------------------> Add Item <--------------------");
            Console.WriteLine("[1]: Get item by id, [0]: Back to Menu");

            try
            {
                int value = Convert.ToInt32(Console.ReadLine());
                if (value == 1)
                {
                    try
                    {
                        Console.Write("Enter Id of item: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var item = _inventoryRepository.GetById(id);

                        if (item != null)
                        {
                            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20}", "ID", "Name", "Price", "Quantity");
                            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-20}", item.Id, item.Name, item.Price, item.Quantity);
                        }
                        else
                        {
                            Console.WriteLine("Data not fount");
                        }
                        GetItemById();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input - Id must be a number");
                        GetItemById();
                    }
                }
                else if (value == 0)
                {
                    MenuBar(_inventoryRepository);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    GetItemById();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input - Enter Number");
                GetItemById();
            }
        }

        public void Close()
        {
            Console.Clear();
        }
    }
}
