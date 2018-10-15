using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            // run tests and print out if tests passed or not
            Console.WriteLine(tests());

            //string readword = Console.ReadLine();
            //your code to get user input and call TranslateWord method here

        }
        public static string TranslateWord(string wordinput)
        {
            //Read the word with split in case of multiple words
            String[] word = wordinput.Split(' ');
            string[] lowerCaseWord = new String[5];

            //Loop for each word after split
            for (int i = 0; i < word.Length; i++)
            {
                word[i] = word[i].ToLower();
                //Find the first vowel index in the word and the word starts with "y"
                if (word[i].StartsWith("y"))
                {
                    int firstVowelIndex = word[i].IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u' });
                    //If the vowel is in the second letter split the word from consonant and include at end. Add 'ay'

                    string firstPart = word[i].Substring(0, firstVowelIndex);
                    string secondPart = word[i].Substring(firstVowelIndex);

                    lowerCaseWord[i] = secondPart + firstPart + "ay";
                }

                else
                {
                    int firstVowelIndex = word[i].IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u', 'y' });

                    //If the vowel is in the first letter, keep the word and add 'yay' at the end
                    if (firstVowelIndex == 0)
                    {
                        lowerCaseWord[i] = word[i] + "yay";
                    }
                    //If the vowel is in the second letter split the word from consonant and include at end. Add 'ay'
                    else if (firstVowelIndex > 0)
                    {
                        string firstPart = word[i].Substring(0, firstVowelIndex);
                        string secondPart = word[i].Substring(firstVowelIndex);

                        lowerCaseWord[i] = secondPart + firstPart + "ay";
                    }
                    else
                    {
                        lowerCaseWord[i] = word[i] + "ay";
                    }

                }
            }
            //Join the split words together at the end
            string lowerCaseString = String.Join(" ", lowerCaseWord);
            //Read the word
            return lowerCaseString;
        }
        public static bool tests()
        {  // your code goes here
            return
            TranslateWord("fox") == "oxfay";
        }
    }
}