using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string Filename = @"C:\Users\sorat\Documents\csharp-workbook\Files\words_alpha.txt";
            string computerGuess = RandomWord(Filename).Trim();

            Console.WriteLine("hint: word is {0}", computerGuess);

            bool correct = false;

            while (correct != true)
            {
                Console.WriteLine("Please guess what the random word is:");
                string userGuess = Console.ReadLine();

                if (computerGuess == userGuess)
                {
                    Console.WriteLine("You have guessed correctly!");
                    correct = true;
                }
                else
                {
                    Guess(computerGuess, userGuess);
                }
            }
            Console.Read();
        }


        static string RandomWord(string Filename)
        {
            string fileContent = File.ReadAllText(Filename);
            string[] wordArray;
            wordArray = fileContent.Split('\n');

            Random r = new Random();
            int randomInt = r.Next(0, wordArray.Length);
            string randomWord = wordArray[randomInt];

            return randomWord;
        }

        static void Guess(string computerGuess, string userGuess)
        {
            int Guesser = string.Compare(computerGuess, userGuess);
            string GuesserString = Guesser == 1 ? "after" : "before";
            Console.WriteLine("My word is {0} the word {1}.", GuesserString, userGuess);
        }
    }
}
