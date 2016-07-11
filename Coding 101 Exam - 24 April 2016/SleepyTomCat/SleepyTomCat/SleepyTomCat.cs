

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SleepyTomCat
    {
        static void Main()
        {
            int daysOff = int.Parse(Console.ReadLine());

            int offDaysPlayMinutes = daysOff * 127;
            int workDaysPlayMinutes = (365 - daysOff) * 63;
            int totalPlayMinutes = offDaysPlayMinutes + workDaysPlayMinutes;

            if (totalPlayMinutes >30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", (totalPlayMinutes - 30000)/60, (totalPlayMinutes - 30000) % 60);
            }
            else if (totalPlayMinutes < 30000)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play", (30000- totalPlayMinutes) / 60, (30000 - totalPlayMinutes) % 60);
            }
        }
    }
}
