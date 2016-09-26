

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

            double normalPlays = (48 - weekendsInHometow )* 3.0 / 4.0;
            double holidayPlays = holidays * 2.0 / 3.0;
            double hometownPlays = weekendsInHometow;

            double totalPlays = normalPlays + holidayPlays + hometownPlays;
            if (t == "leap")
            {
                totalPlays *= 1.15;
            }

            Console.WriteLine((int)totalPlays);
        }
    }
}
