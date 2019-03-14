using System;

namespace Candles
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] candles = new int[] {2,5,3,1,5};
            int length   = candles.Length;
            int totalCandlesBlownOut = birthdayCakeCounter(length, candles);
    
            Console.WriteLine("The total number of candles blown out is {0}", totalCandlesBlownOut);
        }

        public static int birthdayCakeCounter(int length, int [] candles)
        {
            int greatest = 0;
            for (int i = 0; i < length; i++)
            {
                if(greatest <= candles[i])
                {
                    greatest = candles[i];
                }
            }
            int count = 0;
            for(int i = 0; i < length; i++)
            {
                if(greatest == candles[i])
                count++;
            }
            return count;
        }
    }
}
