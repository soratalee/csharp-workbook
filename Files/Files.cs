using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void WriteFile(string Filename)
        {
            File.WriteAllText(Filename, "This is a text file");
        }

        static void EditFile(string Filename)
        {
            string text = File.ReadAllText(Filename);
            text = text.Replace("text file", "text file, and I can edit it.");
            File.WriteAllText(Filename, text);
        }

        static void ReadFile(string Filename)
        {
            Console.WriteLine(File.ReadAllText(Filename));
        }

        static void DeleteFile(string Filename)
        {
            File.Delete(Filename);
        }

        static void NumberOfWords(string Filename)
        {
            string fileContent = File.ReadAllText(Filename);
            int a = 0;
            int count = 0;

            while (a <= fileContent.Length - 1)
            {
                if (fileContent[a] == ' ' || fileContent[a] == '\n' || fileContent[a] == '\t')
                {
                    count++;                   
                }
                a++; 
            }
            Console.WriteLine("The total number of words in this file are: {0}", count);
        }

        static void LongestWord(string Filename)
        {
            string fileContent = File.ReadAllText(Filename);
            string fileContentReplace = fileContent.Replace(",", "");
            string[] wordsArray;

            wordsArray = fileContentReplace.Split(' ');
            string largestWord = wordsArray[0];

            for(int i = 1; i < wordsArray.Length; i++)
            {
                if (largestWord.Length < wordsArray[i].Length)
                {
                    largestWord = wordsArray[i];
                }
            }
            Console.WriteLine("The largest word in the sentence is: {0}",largestWord);
        }

        static void Main(string[] args)
        {
            string Filename = @"C:\Users\sorat\Documents\csharp-workbook\mydoc.txt";
            WriteFile(Filename);
            EditFile(Filename);
            ReadFile(Filename);
            NumberOfWords(Filename);
            LongestWord(Filename);
            DeleteFile(Filename);

            Console.Read();
        }
    }
}

