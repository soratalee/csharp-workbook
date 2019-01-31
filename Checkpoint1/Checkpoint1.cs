using System;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainders.
            Console.WriteLine(DivisibleByThree());
            /*Write a program and continuously ask the user to enter a number or "ok" to exit. 
            Calculate the sum of all the previously entered numbers and display it on the console.*/
            CalculateSum();
            /* Write a program and ask the user to enter a number. Computer the factorial of the number
            and print it on the console. */
            CalculateFactorial();
            /*Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess
            the number. If the user guesses the number, display "You Won", otherwise, display "You lost". */
            GuessNumberGame();
            /*Write a program and ask the user to enter a series of numbers separated by comma. Find the 
            maximum of the numbers and display it on the console.*/
            largestNumber();

        }
        public static int DivisibleByThree() //For Program #1
        {
            int count = 0;
            for (int i = 1; i < 100; i++)
            {
                if (i % 3 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public static bool CalculateSum()
        {
            String sumInput = "";
            int sumTotal = 0;
            Console.WriteLine("Please enter a number to include in the addition. Or enter 'ok' to exit.");
            //Loop for user input until they enter "ok"
            do
            {
                try
                {
                    sumInput = (Console.ReadLine());
                    //if the user's input is anything other than "ok"
                    if (sumInput.ToLower() != "ok")
                    {
                        sumTotal = sumTotal + Convert.ToInt32(sumInput);
                        Console.WriteLine("Your current total is: " + sumTotal);
                    }
                }
                //catch for invalid input including strings
                catch
                {
                    Console.WriteLine("Please enter a valid number! Otherwise, please enter 'ok' to exit");
                }
            }
            //"ok" ends the loop
            while (sumInput.ToLower() != "ok");
            return true;
        }
        public static bool CalculateFactorial()
        {
            int facInput = 0;
            int facOrig = 0;
            bool Calculate = false;
            //Loop for until user enters a number
            while
            (
                Calculate == false
            )
            {
                try
                {
                    Console.WriteLine("Please enter a number to do a factorial on.");
                    facInput = (Convert.ToInt32(Console.ReadLine()));
                    //Test for positive integers
                    if (TestFactorial(facInput))
                    {
                        //int value of the original user input goes to facOrig
                        facOrig = facInput;
                        for (int i = facInput; i > 1; i--)
                        {
                            facInput = facInput * (i - 1);
                        }
                        Console.WriteLine(facOrig + "! = " + facInput);
                        //Once user inputs a number, bool Calculate becomes true, ending the loop
                        Calculate = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a positive number!");
                    }
                }
                catch
                {
                    Console.WriteLine("Error: invalid number!");
                }
            }
            return true;
        }
        public static bool TestFactorial(int facInput)
        //Factorial Input test for positive integers
        {
            if (facInput >= 0)
            {
                return true;
            }
            else return false;
        }


        public static bool GuessNumberGame()
        {
            //Init Random Generator
            int ComputerGuess = RandomGenerator();
            int PlayerGuess = 0;
            bool CorrectGuess = false;
            //Grant player 4 chances for guessing
            int Chance = 4;
            Console.WriteLine("Guess the number (1-10)");
            Console.WriteLine("(The number that the Computer chose is: " + ComputerGuess + ")");
            //As long as player has a chance and they have not guess correctly, run loop
            while (Chance > 0 && CorrectGuess != true)
            {
                try
                {
                    PlayerGuess = Convert.ToInt32((Console.ReadLine()));
                }
                catch
                {
                    Console.WriteLine("You have entered an invalid number. Please enter a valid number 1 through 10!");
                }
                if (PlayerGuess == ComputerGuess)
                {
                    Console.WriteLine("You guessed correctly!");
                    CorrectGuess = true;
                }
                else
                {
                    //If player does not guess correctly, minus a chance and display text
                    --Chance;
                    Console.WriteLine("Your guess was incorrect. You have (" + Convert.ToString(Chance) + ") chance(s) left.");
                }
            }
            return true;
        }

        public static int RandomGenerator()
        //Random Generator between 1 and 10
        {
            Random r = new Random();
            int RandomNum = (r.Next(1, 11));
            return RandomNum;
        }
        public static bool largestNumber()
        {
            Console.WriteLine("Please enter a series of numbers separated by a comma.");
            bool endLoop = false;
            //Loop until user enters valid data
            while (endLoop != true)
            {
                string userInput = Console.ReadLine();
                int[] toArray = { };
                try
                {
                    //Converts userInput values to array, splitting it by comma. Parse values as int
                    toArray = Array.ConvertAll(userInput.Split(','), int.Parse);

                    int largest = toArray[0];
                    //value largest will take on the max value in array
                    for (int i = 1; i < toArray.Length; i++)
                    {
                        if (largest < toArray[i])
                        {
                            largest = toArray[i];
                        }
                    }
                    Console.WriteLine("The largest number is: {0}",largest);
                    endLoop = true;
                }
                catch
                {
                    Console.WriteLine("Please follow the format of numbers separated by commas! ie: 1,2,3,4,5");
                }
            }
            return true;
        }
    }
}
