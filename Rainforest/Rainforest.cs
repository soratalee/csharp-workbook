using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Program
    {
        public static void Main()
        {
            //Instantiate a new company called "Rainforest"
            Company Rainforest = new Company("Rainforest");
            Rainforest.addWarehouse("Houstin");
            Rainforest.addWarehouse("Austin");

            Warehouse Houstin = new Warehouse("Houstin");
            Houstin.addContainerID("Houstin-01");
            Houstin.addContainerID("Houstin-02");

            Warehouse Austin = new Warehouse("Austin");
            Austin.addContainerID("Austin-01");
            Austin.addContainerID("Austin-02");

            Container Houstin01 = new Container("Houstin-01");
            Houstin01.addItem("bananas");
            Houstin01.addItem("apples");

            Container Houstin02 = new Container("Houstin-02");
            Houstin01.addItem("bread");
            Houstin01.addItem("milk");

            Container Austin01 = new Container("Austin-01");
            Austin01.addItem("strawberry");
            Austin01.addItem("pineapple");

            Container Austin02 = new Container("Austin-02");
            Austin02.addItem("orange juice");
            Austin02.addItem("salad");

            //Console.WriteLine(Austin01.getManifest());
            foreach (object o in Warehouse)
            {

            }
            Console.Read();
        }
    }
    public class Company
    {
        public List<Warehouse> warehouseList = new List<Warehouse>();
        public Company(string warehouseName)
        {
            warehouseList.Add(new Warehouse(warehouseName));
        }
        public void addWarehouse(string name)
        {
            warehouseList.Add(new Warehouse(name));
        }
    }
    public class Warehouse
    {
        string location = "";
        string containerID = "";
        //int size = 0;
        public List<Container> containerList = new List<Container>();
        public Warehouse(string location)
        {
            this.location = location;
        }
        public void addContainerID(string containerID)
        {
            containerList.Add(new Container(containerID));
        }
        public string getID()
        {
            return this.containerID;
        }
    }
    public class Container
    {
        //int id = 0;
        string itemName = "";
        // /int size = 0;
        public List<Item> itemList = new List<Item>();
        public Container(string itemName)
        {
            this.itemName = itemName;
        }
        public void addItem(string item)
        {
            itemList.Add(new Item(itemName));
        }
        public string getitemName()
        {
            return this.itemName;
        }
    }
    public class Item
    {
        //int id = 0;
        string itemName = "";
        //int size = 0;
        public List<string> itemID = new List<string>();
        public Item(string itemName)
        {
            this.itemName = itemName;
        }
    }
}