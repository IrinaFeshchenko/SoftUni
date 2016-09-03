

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DayOfWeek
    {
        static void Main()
        {
            int day = int.Parse(Console.ReadLine());

            string[] weekDays = new string[]{ "Monday", "Tuesday", "Wednesday", "Thursday", "Friday","Saturday", "Sunday"};

            try
            {
                Console.WriteLine(weekDays[day-1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Day!"); ;
            }
        }
    }
}
