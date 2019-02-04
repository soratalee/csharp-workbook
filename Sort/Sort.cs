using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any numbers in any order followed by a comma between numbers:");
            string userInput = Console.ReadLine();
            int[] toArray = { };

            try
            {
                toArray = Array.ConvertAll(userInput.Split(','), int.Parse);
                int count = toArray.Length;
                int i;
                for (i = 0; i<count; i++)
                {
                    for (int j=i+1; j<count; j++)
                    {
                        if (toArray[j] < toArray[i])
                        {
                            int placeHolder = toArray[i];
                            toArray[i] = toArray[j];
                            toArray[j] = placeHolder;
                        }
                    }
                }
                Console.WriteLine("Ascending order of the values is: ");
                for (i = 0; i < count; i++)
                {
                    Console.Write(toArray[i] + " ");
                } 
            }
            catch
            {
                Console.WriteLine("Please follow the format of numbers separated by commas! ie: 1,2,3,4,5");
            }
        }
    }
}
