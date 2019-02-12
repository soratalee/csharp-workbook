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
            //theAnswer = new String[] { "a", "b", "c", "d" };
            theAnswer = new String[4];
            //Guesses as a list of rows. New Row
            guesses = new List<Row>();
        }
        //Method for run
        public void run()
        {
            //Start out game is not won.
            bool won = false;
            //Keep track of turns
            int numTurns = 10;
            //Random Answer
            for (int a = 0; a < 4; a++)
            {
                theAnswer[a] = GetLetter().ToString();
            }
            //Display Cheat
            Console.WriteLine("Cheat-Sheet: [{0}]",string.Join("", theAnswer));

            //While the game is not won, and less than 10 turns have been played, process the game.
            while (!won && numTurns > 0)
            {
                //Display turns left
                Console.WriteLine("You have {0} turns left.", numTurns);
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
                    won = checkForWin(newGuess);

                    String theHint = getHint(newGuess);
                    newGuess.hint = theHint;

                    //If the game hasn't been won, display hint
                    if (!won)
                    {
                        Console.WriteLine("Your hint is " + theHint);
                    }
                    else
                    {
                        Console.WriteLine("You have won!");
                        Console.ReadLine();
                    }
                    //increment the number of turns played
                    numTurns--;
                }
            }
        }

        public String getHint(Row newGuess)
        {
            Row lastGuess = guesses[guesses.Count - 1];
            int Red = 0;
            int White = 0;

            //Clone theAnswer so input doesn't overwrite the answer.
            string[] theAnswerClone = (string[])this.theAnswer.Clone();
            //Red for letter and position matching
            for (int i = 0; i < 4; i++)
            {
                //if position 'i' matches with the ball's position 'i', grant Red flag
                if (theAnswerClone[i] == newGuess.balls[i].letter)
                {
                    Red++;
                }
            }
            for (int b = 0; b < 4; b++)
            {
                //Creates array index and checks if the input letters exist within answer
                int foundIndex = Array.IndexOf(theAnswerClone, newGuess.balls[b].letter);
                if (foundIndex > -1)
                {
                    White++;
                    theAnswerClone[foundIndex] = null;
                }
            }
            //Returns Red flag count and White flag count
            return $"{Red} - {White - Red}";
        }

        //Check for win method.
        public bool checkForWin(Row newGuess)
        {
            if (getHint(newGuess) == "4 - 0")
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
        public static char GetLetter()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length - 1);
            return chars[num];
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