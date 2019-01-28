using System;

public class Program
{
    public static void Main()
    {
        string name = "";
        int age = 0;
        int year = DateTime.Now.Year;


        Console.WriteLine("Please enter your age: ");
        age = Convert.ToInt32(Console.ReadLine());

        if (age < 18)
        {
            Console.WriteLine("Sorry you are too young to play");
        }
        else
        {
            Console.WriteLine("You are old enough to play.");
            Console.WriteLine("Please enter your username: ");
            name = Console.ReadLine();
            Console.WriteLine("Hello {0}! You are {1} years old. It is the year {2}.", name, age, year);

        }
    }
}