using System;

namespace week1_2
{
    class Program
    {
        static void Main(string[] args)
        {
        /*1. Write a C# program that takes two numbers as input, adds them together, and displays the result of that operation*/
            Double x = 0;
            Double y = 0;

            Console.WriteLine("Enter any whole number to add:");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter in the next whole number:");
            y = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine(Convert.ToString(x)+" + "+Convert.ToString(y) +" = "+ Convert.ToString(x+y));
        /*2. Write a C# program that converts yards to inches. */
            Double Yard = 0;

            Console.WriteLine("Enter an amount of Yard you want converted to Inches:");
            Yard = Convert.ToDouble(Console.ReadLine());
            
            Double Inches = Yard*36;
            
            Console.WriteLine(Convert.ToString(Yard)+" Yards equal "+Convert.ToString(Inches)+" Inches.");

        /*3. Create and define the variable people as true. */

            bool people = true;
            Console.WriteLine(people);

        /*4. Create and define the variable f as false. */

            bool f = false;
            Console.WriteLine(f);

        /*5. Create and define the variable num to be a decimal. */

            decimal num = 3.14m;
            Console.WriteLine(num);  

        /*6. Display the product of num multiplied by itself. */

            Console.WriteLine(num*num);     

        /*7. Create the following variables with your personal information:. */

            string firstName = "Sung-ung";
            string lastName = "Lee";
            int age = 29;
            string job = "Database Software Engineer";
            /*string favoriteBand = "N/A";*/
            string favoriteSportsTeam = "New York Excelsior";

        /*8. Create the following variables with your personal information:. */
         
            Console.WriteLine("Hello, my name is "+firstName+" "+
                lastName+". I am "+Convert.ToInt32(age)+" years old. I work as a "
                +job+". My favorite sports team is "+favoriteSportsTeam+".");

        /*9. Experiment with Console.WriteLine(); to print out different pieces of your personal information. */
            
            Convert.ToInt32(num);

            Console.WriteLine(num);

        /*10. Print to the console the sum, product, difference, and quotient of 100 and 10. */

            int a = 100;
            int b = 10;

            Console.WriteLine("The sum of "+Convert.ToString(a)+" and "+Convert.ToString(b)+" is "+Convert.ToString(a+b));
            Console.WriteLine("The product of "+Convert.ToString(a)+" and "+Convert.ToString(b)+" is "+Convert.ToString(a*b));
            Console.WriteLine("The difference of "+Convert.ToString(a)+" and "+Convert.ToString(b)+" is "+Convert.ToString(a-b));
            Console.WriteLine("The quotient of "+Convert.ToString(a)+" and "+Convert.ToString(b)+" is "+Convert.ToString(a/b));

        }
    }
}
