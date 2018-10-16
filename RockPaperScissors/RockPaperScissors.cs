using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter your hand:");
            string hand1 = Console.ReadLine().ToLower();
            string hand2 = ComputerHandGenerator();
            Console.WriteLine(CompareHands(hand1, hand2));

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static string CompareHands(string hand1, string hand2)
        {
            String Verdict = "";

            //Fixes for scissor text
            if (hand1.ToLower() == "scissors")
            {
                hand1 = "scissor";
            }

            // Your code here
            if (hand1 == hand2)
            {
                Verdict = "It's a tie!";
            }
            if ((hand1.ToLower() == "rock" && hand2.ToLower() == "scissor") | (hand1.ToLower() == "scissor" && hand2.ToLower() == "paper") | (hand1.ToLower() == "paper" && hand2.ToLower() == "rock"))
            {
                Verdict = "You win!";
            }
            if ((hand1.ToLower() == "scissor" && hand2.ToLower() == "rock") | (hand1.ToLower() == "paper" && hand2.ToLower() == "scissor") | (hand1.ToLower() == "rock" && hand2.ToLower() == "paper"))
            {
                Verdict = "Computer player wins!";
            }
            return Verdict;
        }
        public static string ComputerHandGenerator()
        {
            String ComputerHand = "";
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
                ComputerHand = "scissor";
            }
            return ComputerHand;
        }
    }
}
