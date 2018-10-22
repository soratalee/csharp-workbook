using System;

namespace FizzBuzz
{
    class Program
    {
        //Main Code
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose enter 1 or 2 for the loop method:" +
            "(1) 'For Loop'" +
            "(2) 'While Loop'");
            int Loop_Type = 0;

            //Read Loop Type Input
            Loop_Type = (Convert.ToInt32(Console.ReadLine()));

            //Run the Loop Type
            Loop(Loop_Type);

            //Code here so program does not end automatically
            Console.ReadLine();
        }
        //Loop Codes
        public static void Loop(int Loop_Type)
        {
            //Loop Code Type 1
            if (Loop_Type == 1)
            {
                //For the int value i, while the value is less than 101, run the code below. Then increment by 1
                for (int i = 0; i < 101; i++)
                {
                    //If once the value of i is divideded into 3 and leaves a remainder of 0 left (perfectly divisible by 3) and also likewise by 5
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        Console.WriteLine("Fizz Buzz");
                    }
                    //Otherwise, if once the value of i is divideded into 3 and leaves a remainder of 0 left (perfectly divisible by 3)
                    else if (i % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    //Otherwise, if once the value of i is divideded into 5 and leaves a remainder of 0 left (perfectly divisible by 5)
                    else if (i % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    //Otherwise write the current value of i.
                    else Console.WriteLine(i);
                }
            }
            //Loop Code Type 2
            if (Loop_Type == 2)
            {
                int counter = 1;
                while (counter < 101)
                {
                    //For the int value counter, while the value is less than 101, run the code below. Then increment by 1
                    if (counter % 3 == 0 && counter % 5 == 0)
                    {
                        Console.WriteLine("Fizz Buzz");
                    }
                    //Otherwise, if once the value of counter is divideded into 3 and leaves a remainder of 0 left (perfectly divisible by 3)
                    else if (counter % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    //Otherwise, if once the value of counter is divideded into 5 and leaves a remainder of 0 left (perfectly divisible by 5)
                    else if (counter % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    //Otherwise write the current value of counter.
                    else Console.WriteLine(counter);
                    counter ++;
                }
            }
            //If the value entered in by Reader is not 1 or 2, run this response instead.
            else 
            {
                Console.WriteLine("Please only enter the value 1 or 2!");
            } 
        }
    }
}
