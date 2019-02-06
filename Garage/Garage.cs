using System;


public class Program
{

    public static void Main()
    {
        // instantiating a new instance of car, and  passing "blue" to the constructor;
        Car blueCar = new Car("blue");

        // instantiating a new instance of person, and passing "John Doe" to the constructor;
        Person john = new Person("John", "Smith");

        // instantiating a new instance of Garage class, and passing in 2 to the constructor;
        Garage smallGarage = new Garage(2);

        // calling a method Parkcar of the smallGarage instance, with inputs of blueCar and 0
        smallGarage.ParkCar(blueCar, 0, john);

        // printint out the cars attribute of the small garage
        Console.WriteLine(smallGarage.Cars);
    }
}

class Car
{
    // constructor
    // takes in a string that is the intial string
    public Car(string initialColor)
    {
        // setting the color of the car to be the string passed into the constructor
        Color = initialColor;
    }

    // changes the color of the car, even though it is a private attribute/variable
    public void paintTheCar(String newColor)
    {
        Color = newColor;
    }

    // once the color is set i cannt change it, outisde of this class
    public string Color { get; private set; }
}

class Person
{
    private string firstName;
    private string lastName;
    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
    public string FullName
    {
        get
        {
            return this.firstName + " " + this.lastName;
        }
        set
        {
            string[] names = value.Split(' ');
            this.firstName = names[0];
            this.lastName = names[1];
        }
    }
}


class Garage
{
    // an array of cars ? what does this do? why is it here?

    private Car[] cars;
    private Person[] persons;
    // constructor , int of initial size
    public Garage(int initialSize)
    {
        // setting the size of this garage
        Size = initialSize;
        // instantiating an array of Cars, of size initialsize
        this.cars = new Car[initialSize];
        this.persons = new Person[initialSize];
    }

    //attribute , private for number of slots in the garage.
    public int Size { get; private set; }

    // a method that adds a car to the spot in the cars array
    public void ParkCar(Car car, int spot, Person driver)
    {
        // what if there is a car already in the spot?
        // what if the spot passed in is outside the array?
        cars[spot] = car;
        persons[spot] = driver;
    }


    public string Cars
    {
        get
        {
            String carsString = "";
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i] != null)
                {
                    carsString += String.Format("The {0} car is in spot {1}. {2} is the owner of the car.", cars[i].Color, i, persons[i].FullName);
                    carsString += "\n";
                }
            }
            return carsString;
        }
    }
}

