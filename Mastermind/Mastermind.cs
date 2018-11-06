using System;
using System.Collections.Generic;
namespace MasterMind
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.run();
        }
    }
    class Game
    {
        List<Row> guesses;
        String[] theAnswer;

        public Game()
        {
            theAnswer = new String[] { "a", "b", "c", "d" };
            //Guesses as a list of rows. New Row
            guesses = new List<Row>();
        }
        //Method for run
        public void run()
        {
            //Start out game is not won.
            bool won = false;
            //Keep track of turns
            int numTurns = 0;
            //While the game is not won, and less than 10 turns have been played, process the game.
            while (!won && numTurns < 3)
            {
                //display all the previous guesses
                displayAllGuess();
                //ask the user for the next guess
                Row newGuess = null;
                try
                {
                    newGuess = getUserGuess();
                }
                catch
                {
                    Console.WriteLine("Bad entry. you don't lose a turn");
                }

                if (newGuess != null)
                {
                    //Add their guess to the list of guesses
                    guesses.Add(newGuess);
                    //evaluate their guess, and see if they won

                    String theHint = getHint();
                    newGuess.hint = theHint;

                    //If the game hasn't been won, display hint
                    if (!won)
                    {
                        Console.WriteLine("Your hint is " + theHint);
                    }
                    //increment the number of turns played
                    numTurns++;
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine(newGuess.balls[i]);
                    }

                }
            }
        }

        public String getHint()
        {
            Row lastGuess = guesses[guesses.Count - 1];
            int Red = 0;
            int White = 0;

            //Clone theAnswer so input doesn't overwrite the answer.
            string[] theAnswerClone = (string[])this.theAnswer.Clone();
            //Red for letter and position matching
            Console.WriteLine(theAnswerClone[0]);

            //figures out the score;
            return "0-0";
        }
        public bool checkForWin()
        {
            if (getHint() == "4-0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Getting the user's guess list
        public Row getUserGuess()
        {
            Console.Write("Enter your guess as 4 letters: ");
            String guess = Console.ReadLine();
            guess = guess.ToLower();
            guess = guess.Trim();
            if (guess.Length != 4)
            {
                throw new Exception("Guess should be 4 letters!");
            }

            Row theNewRow = new Row(guess);
            return theNewRow;
        }
        //Method for displaying all guesses
        public void displayAllGuess()
        {
            foreach (Row guess in guesses)
            {
                Console.WriteLine(guess.toString());
            }
        }

    }
    //Class for Row. This keeps track of the user's guesses for a turn
    class Row
    {
        public Ball[] balls { get; set; }
        public string hint { get; set; }
        //Creates a new row with the 4 balls passed in 
        public Row(String letters)
        {
            if (letters.Length != 4)
            {
                throw new Exception("Row contructor takes in a string of 4!");
            }
            else
            {
                balls = new Ball[4];
                char[] temp = letters.ToCharArray();
                for (int i = 0; i < 4; i++)
                {
                    balls[i] = new Ball(temp[i].ToString());
                }
            }
        }
        //returns a string representation of the row
        public String toString()
        {
            string formatted = "";
            foreach (Ball ball in balls)
            {
                formatted += ball.letter + " ";
            }
            return formatted.Trim() + " -> " + hint;
        }
    }

    //Class for Ball
    class Ball
    {
        //Sets the variable Letter
        public string letter { get; private set; }
        //Each Ball has a Letter. Constructor that sets the letters for the ball
        public Ball(string letter)
        {
            this.letter = letter;
        }
    }
}
