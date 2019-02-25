using System;
using System.Collections.Generic;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate classes of cars
            Vehicle Corolla = new Car("Toyota", "Corolla", "DEF-5678", 19000.50);
            Vehicle Civic = new Car("Honda", "Civic", "FED-1209", 20000.99);
            Vehicle Prius = new Car("Toyota", "Prius", "HJK-6789", 28000.99);
            Vehicle Model3 = new Car("Tesla", "Model 3", "CUSTOM123", 79000.95);
            Vehicle Ranger = new Truck("Ford", "Ranger", "GHI-9012", 35000.00);
            Vehicle F150 = new Truck("Ford", "F-150", "IHM-9241", 28155.00);
            Vehicle Sierra = new Truck("GMC", "Sierra", "MIQ-8501", 29600.00);
            Vehicle Tacoma = new Truck("Toyota", "Tacoma", "QOJF-9012", 25500.00);

            //Instantiate classes of carLot
            CarLot Lot1 = new CarLot();
            CarLot Lot2 = new CarLot();

            //Enter in Lot list
            Lot1.addVehicle(Corolla);
            Lot1.addVehicle(Civic);
            Lot1.addVehicle(Prius);
            Lot1.addVehicle(Model3);
            Lot2.addVehicle(Ranger);
            Lot2.addVehicle(F150);
            Lot2.addVehicle(Sierra);
            Lot2.addVehicle(Tacoma);
            
            //Get Description method
            Console.WriteLine(Civic.getDescription());
        }

    }

    public abstract class Vehicle
    {
        //Vehicle variables
        public string make;
        public string model;
        public string licenseNumber;
        public double price;

        //Vehicle constructor
        public Vehicle(string make, string model, string licenseNumber, double price)
        {
            this.make = make;
            this.model = model;
            this.licenseNumber = licenseNumber;
            this.price = price;
        }

        virtual public string getDescription()
        {
            string desc = String.Format("The make is {0}, the model is {1}. The license number is {2}. The price of the car is: {3}."
            , this.make, this.model, this.licenseNumber, this.price);
            return desc;
        }
    }

    //new class CarLot
    public class CarLot
    {
        public string name;
        //List of vehicles
        public List<Vehicle> vehicleList = new List<Vehicle>();

        //Insert vehicle to roster
        public void addVehicle(List<Vehicle> vehicle)
        {
            this.vehicleList = vehicle;
        }

        //Inventory list method
        public void printInventory()
        {

        }
    }

    public class Car : Vehicle
    {
        string typeOfCar;
        int numDoors = 0;

        public Car (string make, string model, string licenseNumber, double price, string typeOfCar, int numDoors) : base(make, model, licenseNumber, price)
        {

        }
    }
    public class Truck : Vehicle
    {
        int bedSize = 0;

        public Truck (string make, string model, string licenseNumber, double price, int bedSize) : base(make, model, licenseNumber, price)
        {

        }
    }

}


