

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Volleyball
    {
        static void Main()
        {
            string t = Console.ReadLine().Trim();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsInHometow = int.Parse(Console.ReadLine());

            decimal normalPlays = (48 - weekendsInHometow )* 3m / 4m;
            decimal holidayPlays = (holidays * 2m) / 3m;
            decimal hometownPlays = weekendsInHometow;

            decimal totalPlays = normalPlays + holidayPlays + hometownPlays;
            if (t == "leap")
            {
                totalPlays *= 1.15m;
            }

            Console.WriteLine(Math.Round(totalPlays));
        }
    }
}
