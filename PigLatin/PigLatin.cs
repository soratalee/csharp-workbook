using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            // run tests and print out if tests passed or not
            if (tests())
            {
                Console.WriteLine("Tests passed.");
            } else {
                Console.WriteLine("Tests failed.");
            }
            
            //your code to get user input and call TranslateWord method here
            Console.WriteLine(TranslateWord(Console.ReadLine()));

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
                    //Array of vowels
                    int firstVowelIndex = word[i].IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u' });
                    //If the vowel is in the second letter split the word from consonant and include at end. Add 'ay'

                    string firstPart = word[i].Substring(0, firstVowelIndex);
                    string secondPart = word[i].Substring(firstVowelIndex);

                    lowerCaseWord[i] = secondPart + firstPart + "ay";
                }

                else 
                {
                    //Array of vowels including "Y"
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
            return lowerCaseString.Trim();
        }
        public static bool tests()
        {
            // Test various words
            return 
                TranslateWord("elephant") == "elephantyay" &&
                TranslateWord("fox") == "oxfay" &&
                TranslateWord("choice") == "oicechay" && 
                TranslateWord("dye") == "yeday" && 
                TranslateWord("bystander") == "ystanderbay" &&
                TranslateWord("yellow") == "ellowyay" &&
                TranslateWord("tsktsk") == "tsktskay";//
        }
    }
}
