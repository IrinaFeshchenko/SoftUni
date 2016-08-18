

namespace Namespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TravellerBob
    {
        static void Main()
        {
            string yearType = Console.ReadLine();
            int cMonths = int.Parse(Console.ReadLine());
            int fMonths = int.Parse(Console.ReadLine());
            int nMonths = 12 - cMonths - fMonths;

            int cPerWeek = 3;
            int fPerWeek = 2;
            //int nPerWeek = 2;

            int cWeeksAMonth = 4;
            int fWeeksAMonth = 2;
            //int nWeeksAMonth = 0;

            int cTotalPerMonth = cPerWeek * cWeeksAMonth;
            int fTotalPerMonth = fPerWeek * fWeeksAMonth;
            decimal nTotalPerMonth = (decimal)cTotalPerMonth*3/5;

            int cTotalPerYear = cTotalPerMonth * cMonths;
            int fTotalPerYear = fTotalPerMonth * fMonths;
            decimal nTotalPerYear = nTotalPerMonth * nMonths;

            decimal yearTravels = cTotalPerYear+ fTotalPerYear+ nTotalPerYear;

            if (yearType == "leap")
            {
                yearTravels *= 1.05m;
            }

            Console.WriteLine(Math.Floor(yearTravels));
        }
    }
}
