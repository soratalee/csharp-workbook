using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            
            //Read user's input
            Console.WriteLine("Enter your hand:");
            string hand1 = Console.ReadLine().ToLower();
            string hand2 = ComputerHandGenerator();

            //Tests 1 nd 2 for valid input
            if (test1(hand1)&&test1(hand2))
            {
                Console.WriteLine("You chose "+hand1+". The computer chose "+hand2+". ");
                Console.WriteLine(CompareHands(hand1, hand2));
            }
            else Console.WriteLine("Error. Please enter a valid hand ('rock','paper','scissors')!");

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static string CompareHands(string hand1, string hand2)
        {
            String Verdict = "";

            //Fixes for scissor text
            if (hand1.ToLower() == "scissor")
            {
                hand1 = "scissors";
            }

            //Win/Loss/Tie logic Returns the outcome to Main
            if (hand1 == hand2)
            {
                Verdict = "You chose "+hand1+". The Computer chose "+ hand2+"... It's a tie!";
            }
            if ((hand1.ToLower() == "rock" && hand2.ToLower() == "scissors") | (hand1.ToLower() == "scissors" && hand2.ToLower() == "paper") | (hand1.ToLower() == "paper" && hand2.ToLower() == "rock"))
            {
                Verdict = "You chose "+hand1+". The Computer chose "+ hand2+"... You win!";
            }
            if ((hand1.ToLower() == "scissors" && hand2.ToLower() == "rock") | (hand1.ToLower() == "paper" && hand2.ToLower() == "scissors") | (hand1.ToLower() == "rock" && hand2.ToLower() == "paper"))
            {
                Verdict = "You chose "+hand1+". The Computer chose "+ hand2+"... Computer player wins!";
            }
            return Verdict;
        }

        //Computer random generator based on numberical value
        public static string ComputerHandGenerator()
        {
            String ComputerHand = "";
            //Random numbers 1-3
            Random r = new Random();
            int Random = (r.Next(1,4));

            if (Random == 1)
            {
                ComputerHand = "rock";
            }
            if (Random == 2)
            {
                ComputerHand = "paper";
            }
            if (Random == 3)
            {
                ComputerHand = "scissors";
            }
            return ComputerHand;
        }

        //Test 1 for Human Input
        public static bool test1(string hand1)
        {
            return
                hand1 == "rock" ||
                hand1 == "scissors" ||
                hand1 == "scissor" ||
                hand1 == "paper";
        }
        //Test 2 for Computer Input
        public static bool test2(string hand2)
        {
            return
                hand2 == "rock" ||
                hand2 == "scissors" ||
                hand2 == "scissor" ||
                hand2 == "paper";
        }
    }
}
