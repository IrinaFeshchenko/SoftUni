

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class JoroTheFootballPlayer
    {
        static void Main()
        {
            string t = Console.ReadLine().Trim();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsInHometow = int.Parse(Console.ReadLine());

            decimal normalPlays = (52 - weekendsInHometow) * 2 / 3;
            decimal holidayPlays = holidays / 2;
            decimal hometownPlays = weekendsInHometow;

            decimal totalPlays = normalPlays + holidayPlays + hometownPlays;
            if (t == "t")
            {
                totalPlays += 3;
            }

            Console.WriteLine(totalPlays);
        }
    }
}
