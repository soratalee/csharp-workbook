using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate classes
            Vehicle Motorcycle = new Cruiser("Kawasaki", "Ninja", 2, true);
            Vehicle Car = new Convertible("Toyota", "Corolla", 4, true);
            Vehicle Truck = new BedSize("Ford", "Ranger", 4, 2);
        
            Console.WriteLine(Motorcycle.getDescription());
        }

    }

    public class Vehicle
    {
        public String Make;
        public String Model;
        public int NumWheels;

        public Vehicle(String make, String model, int numWheels)
        {
            this.Make = make;
            this.Model = model;
            this.NumWheels = numWheels;
        }

        virtual public string getDescription()
        {
            string desc = String.Format("The make is {0}, the model is {1}, and it has {2} wheels."
            , this.Make, this.Model, this.NumWheels);
            return desc;
        }
    }

    public class Cruiser : Vehicle
    {
        bool isCruiser;

        public Cruiser(String make, String model, int numWheels, bool isCruiser) : base(make, model, numWheels)
        {
            this.isCruiser = isCruiser;
        }
        override public string getDescription()
        {
            string desc = String.Format("The make is {0}, the model is {1}, and it has {2} wheels. {3}."
            , this.Make, this.Model, this.NumWheels, this.isCruiser? "And it is a cruiser." : "It is not a cruiser.");
            return desc;
        }
    }
    public class Convertible : Vehicle
    {
        bool isConvertible;

        public Convertible(String make, String model, int numWheels, bool isConvertible) : base(make, model, numWheels)
        {
            this.isConvertible = isConvertible;
        }
        override public string getDescription()
        {
            string desc = String.Format("The make is {0}, the model is {1}, and it has {2} wheels. It is a {3}."
            , this.Make, this.Model, this.NumWheels, this.isConvertible);
            return desc;
        }
    }
    public class BedSize : Vehicle
    {
        int bedSizeCount;

        public BedSize(String make, String model, int numWheels, int bedSizeCount) : base(make, model, numWheels)
        {
            this.bedSizeCount = bedSizeCount;
        }
        override public string getDescription()
        {
            string desc = String.Format("The make is {0}, the model is {1}, and it has {2} wheels. It has a bedsize of: {3}."
            , this.Make, this.Model, this.NumWheels, this.bedSizeCount);
            return desc;
        }
    }

}


