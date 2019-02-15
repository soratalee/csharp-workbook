using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Program
    {
        public static void Main()
        {
            //Instantiate Inventory
            Inventory inventorylist = new Inventory();

            //Instantiate new Warehouses
            Warehouse Houstin = new Warehouse("Houstin", new Dictionary<string, Container>());
            Warehouse Austin = new Warehouse("Austin", new Dictionary<string, Container>());

            //Instantiate new Containers
            Container Houstin01 = new Container("Houstin-01", new List<Item>());
            Container Houstin02 = new Container("Houstin-02", new List<Item>());
            Container Austin01 = new Container("Austin-01", new List<Item>());
            Container Austin02 = new Container("Austin-02", new List<Item>());

            //Instantiate new Items
            Item milk = new Item("milk");
            Item bread = new Item("bread");
            Item banana = new Item("banana");
            Item apple = new Item("apple");
            Item salad = new Item("salad");
            Item juice = new Item("juice");
            Item ham = new Item("ham");
            Item pineapple = new Item("pineapple");

            //Insert Warehouse to Inventory
            inventorylist.inventory.Add("Houstin", Houstin);
            inventorylist.inventory.Add("Austin", Austin);

            //Insert Container to Warehouse
            Houstin.containerList.Add("Houstin01", Houstin01);
            Houstin.containerList.Add("Houstin02", Houstin02);
            Austin.containerList.Add("Austin01", Austin01);
            Austin.containerList.Add("Austin02", Austin02);

            //Insert Item to Container
            Austin01.itemList.Add(milk);
            Austin01.itemList.Add(bread);
            Austin02.itemList.Add(banana);
            Austin02.itemList.Add(milk);
            Houstin01.itemList.Add(salad);
            Houstin01.itemList.Add(bread);
            Houstin02.itemList.Add(juice);
            Houstin02.itemList.Add(ham);
            Houstin02.itemList.Add(pineapple);

            inventorylist.printInventory();

            //Index of Items
            Console.WriteLine("Enter an item you want to look up from the list above: ");
            string itemSearch = Console.ReadLine();

            inventorylist.itemIndex(itemSearch);
        }

        public class Inventory
        {
            public Dictionary<string, Warehouse> inventory = new Dictionary<string, Warehouse>();
            public void printInventory()
            {
                foreach (KeyValuePair<string, Warehouse> warehouse in this.inventory)
                {
                    Console.WriteLine("Warehouse: " + warehouse.Key);
                    foreach (KeyValuePair<string, Container> containers in warehouse.Value.containerList)
                    {
                        Console.WriteLine("     Container: " + containers.Key);
                        foreach (Item item in containers.Value.itemList)
                        {
                            Console.WriteLine("         Item: " + item.itemName);
                        }
                    }
                }
            }

            public void itemIndex(string itemSearch)
            {
                foreach (KeyValuePair<string, Warehouse> warehouse in this.inventory)
                {
                    foreach (KeyValuePair<string, Container> containers in warehouse.Value.containerList)
                    {
                        foreach (Item item in containers.Value.itemList)
                        {
                            if (item.itemName == itemSearch)
                            {
                                Console.WriteLine("||" + itemSearch + " is available in {0}", containers.Key);
                            }
                        }
                    }
                }

            }
        }
        public class Item
        {
            //int id = 0;
            public string itemName { get; private set; }
            //int size = 0
            public Item(string itemName)
            {
                this.itemName = itemName;
            }
        }
        public class Container
        {
            public string containerName { get; private set; }
            public List<Item> itemList = new List<Item>();
            //Creating a constructor for the class Container
            public Container(string containerName, List<Item> Items)
            {
                this.containerName = containerName;
                this.itemList = Items;
            }
        }
        public class Warehouse
        {
            public string warehouseName { get; private set; }
            public Dictionary<string, Container> containerList = new Dictionary<string, Container>();
            //public List<Container> containerList = new List<Container>();
            //Creating a constructor for the class Container
            public Warehouse(string warehouseName, Dictionary<string, Container> Containers)
            {
                this.warehouseName = warehouseName;
                this.containerList = Containers;
            }
        }
    }
}