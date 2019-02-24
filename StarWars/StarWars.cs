using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        bool QuitRoster = false;
        Person leia = new Person("Leia", "Organa", "Rebel");
        Person han = new Person("Han", "Solo", "Rebel");
        Person luke = new Person("Luke", "Skywalker", "Jedi");
        Person yoda = new Person("Yoda", "", "Jedi");
        Ship falcon = new Ship("Rebel", "Smuggling", 2, "Millenium Falcon");
        Ship tie = new Ship("Tie", "Fighter", 2, "Tie Fighter");
        Ship xwing = new Ship("X-Wing", "Fighter", 1, "Imperial Fighter");
        Station rebelss = new Station("Rebel Space Station", "Rebel", 5);
        Station deathstar = new Station("Death Star", "Imperial", 10);

        //Enter in crew to ships
        try
        {
            falcon.EnterShip(leia, 0);
            falcon.EnterShip(han, 1);
            tie.EnterShip(luke, 0);
            tie.EnterShip(yoda, 1);
        }
        catch (System.IndexOutOfRangeException e)
        {
            Console.WriteLine(e);
            //Console.WriteLine("Error: You have placed a passenger in an seat that does not exist! Please fix this and rerun.");
            QuitRoster = true;
        }

        //Enter in ships to dock
        try
        {
            rebelss.enterStation(falcon, 0);
            rebelss.enterStation(tie, 1);
        }
        catch
        {
            Console.WriteLine("Error: You have placed a ship in an dock number that does not exist! Please fix this and rerun.");
            QuitRoster = true;
        }
        //Call out the Roster 
        if (QuitRoster != true)
        {
            Console.WriteLine(rebelss.Roster);
        }
    }
}

//Creating a public class: Person
public class Person
{
    private string firstName;
    private string lastName;
    private string alliance;
    //Creating a constructor for the class Person
    public Person(string firstName, string lastName, string alliance)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.alliance = alliance;
    }

    //Sets up the full name based on first name and last name values
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

//Creating a public class: Ship
public class Ship
{
    public Person[] passengers;
    //Creating a constructor for the class Ship
    public Ship(string alliance, string type, int size, string shipName)
    {
        this.Type = type;
        this.Alliance = alliance;

        this.passengers = new Person[size];

        this.shipName = shipName;
    }

//Locks in the values for the string types
    public string Type
    {
        get;
        set;
    }

    public string Alliance
    {
        get;
        set;
    }
    public string shipName
    {
        get;
        set;
    }

    public void EnterShip(Person person, int seat)
    {
        this.passengers[seat] = person;
    }

    public void ExitShip(int seat)
    {
        this.passengers[seat] = null;
    }
    //Change of Alliance in case of capture
    public void allianceChange(string newAlliance)
    {
        this.Alliance = newAlliance;
    }
}

//Creates the class Station
class Station
{
    private string stationName;
    private string Alliance;
    private Ship[] shipDock;

    //Constructor for Station
    public Station(string stationName, string Alliance, int stationSize)
    {
        this.stationName = stationName;
        this.Alliance = Alliance;
        this.shipDock = new Ship[stationSize];
    }
    //populates the lot with the ship. Method
    public void enterStation(Ship Ship, int lot)
    {
        this.shipDock[lot] = Ship;
    }


    //empties the lot
    public void exitStation(int lot)
    {
        this.shipDock[lot] = null;
    }
    //Change of Alliance in case of capture
    public void allianceChange(string newAlliance)
    {
        this.Alliance = newAlliance;
    }

    //Method for Roster
    public string Roster
    {
        get
        {

            foreach (var Ship in shipDock)
            {
                if (Ship == null)
                {
                    //NULL handler
                }
                else
                {
                    Console.WriteLine(String.Format("Ship: {0}", Ship.shipName));
                    foreach (var Person in Ship.passengers)
                    {
                        if (Person == null)
                        {
                            //NULL handler
                        }
                        else
                        {
                            Console.WriteLine(String.Format("   Crew: {0}", Person.FullName));
                        }

                    }
                    Console.WriteLine("-------------------------------");
                }
            }
            return "That's the full list for the Ships and their crewmembers!";
        }
    }
}