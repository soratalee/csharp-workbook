using System;

namespace EnumStruct
{
    class Program
    {
        static void Main(string[] args)
        {

            int Year = 0;

            DaysOfWeek myBirthdayDay = DaysOfWeek.Saturday;

            Console.WriteLine(myBirthdayDay);
            Console.WriteLine((int)myBirthdayDay+1);
            Console.WriteLine((DaysOfWeek)1);
            Console.WriteLine("Please type in a year");
            Year = Convert.ToInt16(Console.ReadLine());

            DateTime birthday = new DateTime(Year, 12, 14);

            Console.WriteLine("The day of the week for {0:d} is {1}.", birthday, birthday.DayOfWeek);

        }
    }

    enum DaysOfWeek
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
    enum DaysOfWeekWithNum
    {
        Sunday = 1, Monday = 2, Tuesday = 3, Wednesday = 4, Thursday = 5, Friday = 6, Saturday = 7
    }
}
