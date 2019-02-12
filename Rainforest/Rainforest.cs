using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Program
    {
        public static void Main()
        {
            Warehouse Houstin = new Warehouse("Houstin");
            Houstin.addContainerID("Houstin-01");
            Houstin.addContainerID("Houstin-02");
            Houstin.addContainerID("Houstin-03");

            Warehouse Austin = new Warehouse("Austin");
            Austin.addContainerID("Austin-01");
            Austin.addContainerID("Austin-02");

            Container Houstin01 = new Container("Houstin-01");
            Houstin01.addItemToContainer("bananas");
            Houstin01.addItemToContainer("apples");

            Item milk = new Item("milk");
            Item bread = new Item("bread");
            Container Houstin02 = new Container("Houstin-02");
            Houstin02.addItemToContainer(milk);

            Container Austin01 = new Container("Austin-01");
            Austin01.addItemToContainer("strawberry");
            Austin01.addItemToContainer("pineapple");

            Container Austin02 = new Container("Austin-02");
            Austin02.addItemToContainer("orange juice");
            Austin02.addItemToContainer("salad");

            Console.WriteLine(Houstin01.printContainer());
            Console.WriteLine("---------------------------");
            Console.WriteLine(Houstin.printWarehouse());
        }
    }
    public class Item
    {
        //int id = 0;
        private string itemName = null; //{get; private set;}
        //int size = 0
        public Item(string itemName)
        {
            this.itemName = itemName;
        }
        public string printItem()
        {
            return itemName;
        }
    }
    public class Container
    {
        //int id = 0;
        string containerName = null;
        string itemName = null;
        // /int size = 0;
        public List<Item> itemList = new List<Item>();
        public Container(string containerName)
        {
            this.containerName = containerName;
        }
        public void addItemToContainer(string item)
        {
            itemList.Add(new Item(itemName = item));
        }
        public string printContainer()
        {
            //Console.WriteLine(containerName);

            string result = "";
            foreach (var o in itemList)
            {
                result += o.printItem() + "\n";
            }
            return result;
        }
    }
    public class Warehouse
    {
        string location = null;
        string containerName = null;
        //int size = 0;
        public List<Container> containerList = new List<Container>();
        public Warehouse(string location)
        {
            this.location = location;
        }
        public void addContainerID(string containerID)
        {
            containerList.Add(new Container(containerName = containerID));
        }
        public string printWarehouse()
        {
            //Console.WriteLine(containerName);

            string result = null;
            foreach (var o in containerList)
            {
                result += o.printContainer() + "\n";
            }
            return result;
        }
    }
}